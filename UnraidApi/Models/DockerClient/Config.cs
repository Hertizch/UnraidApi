using System.Collections.Generic;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Config
    {
        [J("Hostname")] public string Hostname { get; set; }
        [J("Domainname")] public string Domainname { get; set; }
        [J("User")] public string User { get; set; }
        [J("AttachStdin")] public bool AttachStdin { get; set; }
        [J("AttachStdout")] public bool AttachStdout { get; set; }
        [J("AttachStderr")] public bool AttachStderr { get; set; }
        [J("ExposedPorts")] public Dictionary<string, ExposedPort> ExposedPorts { get; set; }
        [J("Tty")] public bool Tty { get; set; }
        [J("OpenStdin")] public bool OpenStdin { get; set; }
        [J("StdinOnce")] public bool StdinOnce { get; set; }
        [J("Env")] public string[] Env { get; set; }
        [J("Cmd")] public string[] Cmd { get; set; }
        [J("ArgsEscaped")] public bool ArgsEscaped { get; set; }
        [J("Image")] public string Image { get; set; }
        [J("Volumes")] public Volumes Volumes { get; set; }
        [J("WorkingDir")] public string WorkingDir { get; set; }
        [J("Entrypoint")] public string[] Entrypoint { get; set; }
        [J("OnBuild")] public object OnBuild { get; set; }
        [J("Labels")] public ExposedPort Labels { get; set; }
    }
}
