using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnraidApi.Endpoints.ApcUpsd;
using UnraidApi.Endpoints.DiskEndpoint;
using UnraidApi.Endpoints.DockerEndpoint;
using UnraidApi.Endpoints.SystemInfoEndpoint;

namespace UnraidApi
{
    public class UnraidApiClient
    {
        private ConnectionInfo _connectionInfo;
        private SshClient _sshClient;
        private SftpClient _sftpClient;
        private bool _redirectUrlIsResolved;

        public UnraidApiClient(string host, string username, string password, [Optional] int port, [Optional] bool useHttps, [Optional] string redirectUrl)
        {
            // Set passed paramaters
            Host = host;
            Username = username;
            Password = password;
            Port = port;
            UseHttps = useHttps;
            RedirectUrl = redirectUrl;

            if (!string.IsNullOrEmpty(RedirectUrl))
                _redirectUrlIsResolved = true;

            _connectionInfo = new ConnectionInfo(Host, Username, new PasswordAuthenticationMethod(Username, Encoding.ASCII.GetBytes(Password)));

            // Initialize endpoint clients
            DiskClient = new DiskClient(this);
            ApcUpsdClient = new ApcUpsdClient(this);
            DockerClient = new DockerClient(this);
            SystemInfoClient = new SystemInfoClient(this);

            // Create connection clients
            _sftpClient = new SftpClient(_connectionInfo);
            _sshClient = new SshClient(_connectionInfo);
        }

        public IDiskClient DiskClient { get; }
        public IApcUpsdClient ApcUpsdClient { get; }
        public IDockerClient DockerClient { get; }
        public ISystemInfoClient SystemInfoClient { get; }

        /// <summary>
        /// Server hostname/ip address
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Server SSH port
        /// Default: 22
        /// </summary>
        public int Port { get; private set; } = 22;

        /// <summary>
        /// Server username
        /// Default: root
        /// </summary>
        public string Username { get; private set; } = "root";

        /// <summary>
        /// Server password
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// If Https/SSL is enabled on server. Default: false
        /// </summary>
        public bool UseHttps { get; private set; }

        /// <summary>
        /// Unraid web ui redirect url, used for https. The url is resolved automatically but can be overwritten
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Unraid timezone
        /// </summary>
        internal string Timezone { get; set; }

        internal async Task<string> GetTimezone()
        {
            var fileStr = await ReadRemoteFile("/var/local/emhttp/var.ini");
            if (fileStr != null)
            {
                var match = Regex.Match(fileStr, "timeZone=\"(.+)\"");
                if (match.Success)
                    return match.Groups[1].Value;
            }

            return null;
        }

        /// <summary>
        /// Open SFTP connection to server and download specified file to string
        /// </summary>
        /// <param name="filePath">Filename to download</param>
        /// <returns>File contents string</returns>
        internal async Task<string> ReadRemoteFile(string filePath, bool refreshHttp = false, bool invokeEmHttp = false)
        {
            string output = null;
            SftpFileStream remoteFileStream = null;

            // Check if we need to update the http page before getting our file
            if (refreshHttp)
            {
                await RefreshHttpPage($"http://{Host}", "/Docker");
            }

            // Check if we need to invoke the emhttpd script before getting our file
            if (invokeEmHttp)
            {
                await InvokeEmHttp();
            }

            await Task.Run(async () =>
            {
                try
                {
                    if (!_sftpClient.IsConnected)
                        _sftpClient.Connect();

                    remoteFileStream = _sftpClient.OpenRead(filePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[ERROR] [UnraidApiClient.ReadRemoteFile(string {filePath})] EXCEPTION: {ex.Message}");
                }
                finally
                {
                    if (remoteFileStream != null)
                        output = await new StreamReader(remoteFileStream).ReadToEndAsync();
                }
            });

            //Debug.WriteLine($"[DEBUG] [UnraidApiClient.ReadRemoteFile(string {filePath})] RETURNED: {output}");

            return output;
        }

        /// <summary>
        /// Open SSH connection to server, execute command and get the response
        /// </summary>
        /// <param name="commandText">Command text to execute</param>
        /// <returns>Response string</returns>
        internal async Task<string> RunCommand(string commandText)
        {
            string output = null;
            SshCommand sshCommand = null;

            await Task.Run(() =>
            {
                try
                {
                    if (!_sshClient.IsConnected)
                        _sshClient.Connect();

                    sshCommand = _sshClient.RunCommand(commandText);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[ERROR] [UnraidApiClient.GetCommandResponse(string {commandText})] EXCEPTION: {ex.Message}");
                }
                finally
                {
                    if (sshCommand.Result != null)
                        output = sshCommand.Result;
                }
            });

            //Debug.WriteLine($"[DEBUG] [UnraidApiClient.GetCommandResponse(string {commandText})] RETURNED: {output}");

            return output;
        }

        private async Task RefreshHttpPage(string url, string urlEnding)
        {
            var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(Username + ":" + Password));
            var myContainer = new CookieContainer();
            var finalRequestUrl = RedirectUrl + urlEnding;

            // Resolve redirect url
            if (!_redirectUrlIsResolved)
            {
                HttpResponseMessage response;
                var client = new HttpClient();
                using (var authString = new StringContent(encoded))
                {
                    response = await client.PostAsync(url + urlEnding, authString);
                }

                var result = await response.Content.ReadAsStringAsync();

                response = await client.GetAsync(new Uri(url + urlEnding));
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    finalRequestUrl = response.RequestMessage.RequestUri.AbsoluteUri;
                    Debug.WriteLine($"finalRequestUrl: {finalRequestUrl}");
                    RedirectUrl = finalRequestUrl;
                    _redirectUrlIsResolved = true;
                }
            }

            // Invoke the http page
            var webRequest = (HttpWebRequest)WebRequest.Create(finalRequestUrl);
            webRequest.Headers.Add("Authorization", "Basic " + encoded);
            webRequest.CookieContainer = myContainer;
            webRequest.PreAuthenticate = true;
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
        }

        private async Task InvokeEmHttp()
        {
            await RunCommand("/usr/local/emhttp/plugins/dynamix/scripts/emhttpd_update");
        }

        /// <summary>
        /// Initiate graceful disconnect from client and clean up used resources
        /// </summary>
        public void Disconnect()
        {
            if (_sshClient != null)
            {
                if (_sshClient.IsConnected)
                    _sshClient.Disconnect();

                _sshClient.Dispose();
            }

            if (_sftpClient != null)
            {
                if (_sftpClient.IsConnected)
                    _sftpClient.Disconnect();

                _sftpClient.Dispose();
            }
        }
    }
}
