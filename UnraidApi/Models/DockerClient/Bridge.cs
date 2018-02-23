using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Bridge
    {
        [J("IPAMConfig")] public object IpamConfig { get; set; }
        [J("Links")] public object Links { get; set; }
        [J("Aliases")] public object Aliases { get; set; }
        [J("NetworkID")] public string NetworkId { get; set; }
        [J("EndpointID")] public string EndpointId { get; set; }
        [J("Gateway")] public string Gateway { get; set; }
        [J("IPAddress")] public string IpAddress { get; set; }
        [J("IPPrefixLen")] public long IpPrefixLen { get; set; }
        [J("IPv6Gateway")] public string IPv6Gateway { get; set; }
        [J("GlobalIPv6Address")] public string GlobalIPv6Address { get; set; }
        [J("GlobalIPv6PrefixLen")] public long GlobalIPv6PrefixLen { get; set; }
        [J("MacAddress")] public string MacAddress { get; set; }
        [J("DriverOpts")] public object DriverOpts { get; set; }
    }
}
