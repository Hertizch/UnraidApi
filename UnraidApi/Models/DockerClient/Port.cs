using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Port
    {
        [J("HostIp")] public string HostIp { get; set; }
        [J("HostPort")] public string HostPort { get; set; }
    }
}
