using System;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class DockerContainer
    {
        [J("Id")] public string Id { get; set; }
        [J("Created")] public DateTime Created { get; set; }
        [J("Path")] public string Path { get; set; }
        [J("Args")] public string[] Args { get; set; }
        [J("State")] public State State { get; set; }
        [J("Image")] public string Image { get; set; }
        [J("ResolvConfPath")] public string ResolvConfPath { get; set; }
        [J("HostnamePath")] public string HostnamePath { get; set; }
        [J("HostsPath")] public string HostsPath { get; set; }
        [J("LogPath")] public string LogPath { get; set; }
        [J("Name")] public string Name { get; set; }
        [J("RestartCount")] public long RestartCount { get; set; }
        [J("Driver")] public string Driver { get; set; }
        [J("Platform")] public string Platform { get; set; }
        [J("MountLabel")] public string MountLabel { get; set; }
        [J("ProcessLabel")] public string ProcessLabel { get; set; }
        [J("AppArmorProfile")] public string AppArmorProfile { get; set; }
        [J("ExecIDs")] public object ExecIDs { get; set; }
        [J("HostConfig")] public HostConfig HostConfig { get; set; }
        [J("GraphDriver")] public GraphDriver GraphDriver { get; set; }
        [J("Mounts")] public Mount[] Mounts { get; set; }
        [J("Config")] public Config Config { get; set; }
        [J("NetworkSettings")] public NetworkSettings NetworkSettings { get; set; }
    }
}
