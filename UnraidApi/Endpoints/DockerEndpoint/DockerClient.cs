using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnraidApi.Utilities;
using System.Linq;

namespace UnraidApi.Endpoints.DockerEndpoint
{
    public class DockerClient : IDockerClient
    {
        private UnraidApiClient _unraidApiClient;
        private List<Data.Docker> _dockers;
        private StringBuilder _argumentsBuilder;
        private Data.Template.Container _container;

        public DockerClient(UnraidApiClient unraidApiClient)
        {
            _unraidApiClient = unraidApiClient;
            _dockers = new List<Data.Docker>();
        }

        public async Task<List<Data.Docker>> GetDockers()
        {
            // Download and read file into memory
            var remoteFileStr = await _unraidApiClient.ReadRemoteFile("/var/local/emhttp/plugins/dynamix.docker.manager/docker.json", true);
            if (remoteFileStr == null) return null;

            // Deserialize json into dictionary
            var rawDockers = JsonConvert.DeserializeObject<Dictionary<string, Data.Docker>>(remoteFileStr, JsonUtilities.JsonSerializerSettings);
            foreach (var rawDocker in rawDockers)
            {
                _dockers.Add(new Data.Docker
                {
                    Name = rawDocker.Key,
                    Running = rawDocker.Value.Running,
                    Autostart = rawDocker.Value.Autostart,
                    Icon = rawDocker.Value.Icon,
                    Url = rawDocker.Value.Url,
                    Registry = rawDocker.Value.Registry,
                    Support = rawDocker.Value.Support,
                    Project = rawDocker.Value.Project,
                    Updated = rawDocker.Value.Updated,
                    TemplatePath = rawDocker.Value.TemplatePath
                });
            }

            return _dockers;
        }

        private async Task<string> GetDockerStartArguments(Data.Docker docker)
        {
            _container = new Data.Template.Container();

            // Get docker template xml file
            var fileStr = await _unraidApiClient.ReadRemoteFile(docker.TemplatePath);
            if (fileStr != null)
            {
                // Deserialize docker template xml
                using (var reader = new StringReader(fileStr))
                {
                    var serializer = new XmlSerializer(typeof(Data.Template.Container));
                    _container = (Data.Template.Container)serializer.Deserialize(reader);
                }
            }

            // Get unraid timezone
            if (string.IsNullOrEmpty(_unraidApiClient.Timezone))
                _unraidApiClient.Timezone = await _unraidApiClient.GetTimezone();

            // start building parameter string
            _argumentsBuilder = new StringBuilder();

            // Add name
            _argumentsBuilder.Append($"--name='{_container.Name}'");

            // Add networking mode
            if (!string.IsNullOrEmpty(_container.Networking.Mode))
                _argumentsBuilder.Append($" --net='{_container.Networking.Mode}'");

            // Add privileged boolean
            if (_container.Privileged)
                _argumentsBuilder.Append($" --privileged='{_container.Privileged}'");

            // Add timezone
            if (!string.IsNullOrEmpty(_unraidApiClient.Timezone))
                _argumentsBuilder.Append($" -e TZ=\"{ _unraidApiClient.Timezone}\"");

            // Add host os
            _argumentsBuilder.Append($" -e HOST_OS=\"unRAID\"");

            // Add environment variables
            if (_container.Environment.Variables.Count > 0)
                foreach (var variable in _container.Environment.Variables)
                    _argumentsBuilder.Append($" -e {variable.Name}=\"{variable.Value}\"");

            // Add ports
            if (_container.Networking.Publish.Ports.Count > 0)
                foreach (var port in _container.Networking.Publish.Ports)
                    _argumentsBuilder.Append($" -p '{port.HostPort}:{port.ContainerPort}/{port.Protocol}'");

            // Add volumes
            if (_container.Data.Volumes.Count > 0)
                foreach (var volume in _container.Data.Volumes)
                    _argumentsBuilder.Append($" -v '{volume.HostDir}':'{volume.ContainerDir}':'{volume.Mode}'");

            // Add extra parameters
            if (!string.IsNullOrEmpty(_container.ExtraParams))
                _argumentsBuilder.Append($" {_container.ExtraParams}");

            // Add repository
            if (!string.IsNullOrEmpty(_container.Registry))
                _argumentsBuilder.Append($" '{_container.Repository}'");

            return _argumentsBuilder.ToString();
        }

        /// <summary>
        /// Stop specified docker
        /// </summary>
        /// <param name="docker">Docker object to stop</param>
        /// <returns>Null</returns>
        public async Task Stop(Data.Docker docker)
        {
            if (!docker.Running) return;

            await _unraidApiClient.RunCommand($"/usr/local/emhttp/plugins/dynamix.docker.manager/scripts/docker stop {docker.Name}");
        }

        /// <summary>
        /// Stop all running dockers
        /// </summary>
        /// <returns>Null</returns>
        public async Task StopAll()
        {
            await _unraidApiClient.RunCommand("/usr/local/emhttp/plugins/dynamix.docker.manager/scripts/docker stop $(docker ps -a -q)");
        }

        /// <summary>
        /// Start specified docker
        /// </summary>
        /// <param name="docker">Docker object to start</param>
        /// <returns>Null</returns>
        public async Task Start(Data.Docker docker)
        {
            if (docker.Running) return;

            // Build run arguments string
            var arguments = await GetDockerStartArguments(docker);
            if (arguments == null) return;

            Debug.WriteLine($"[DEBUG] [DockerClient.Start] Run docker: /usr/local/emhttp/plugins/dynamix.docker.manager/scripts/docker run -d {arguments}");
            await _unraidApiClient.RunCommand($"/usr/local/emhttp/plugins/dynamix.docker.manager/scripts/docker run -d {arguments}");
        }
    }
}
