using System.Collections.Generic;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class NetworkSettings
    {
        [J("Bridge")] public string Bridge { get; set; }
        [J("SandboxID")] public string SandboxId { get; set; }
        [J("HairpinMode")] public bool HairpinMode { get; set; }
        [J("LinkLocalIPv6Address")] public string LinkLocalIPv6Address { get; set; }
        [J("LinkLocalIPv6PrefixLen")] public long LinkLocalIPv6PrefixLen { get; set; }
        [J("Ports")] public Dictionary<string, Port[]> Ports { get; set; }
        [J("SandboxKey")] public string SandboxKey { get; set; }
        [J("SecondaryIPAddresses")] public object SecondaryIpAddresses { get; set; }
        [J("SecondaryIPv6Addresses")] public object SecondaryIPv6Addresses { get; set; }
        [J("EndpointID")] public string EndpointId { get; set; }
        [J("Gateway")] public string Gateway { get; set; }
        [J("GlobalIPv6Address")] public string GlobalIPv6Address { get; set; }
        [J("GlobalIPv6PrefixLen")] public long GlobalIPv6PrefixLen { get; set; }
        [J("IPAddress")] public string IpAddress { get; set; }
        [J("IPPrefixLen")] public long IpPrefixLen { get; set; }
        [J("IPv6Gateway")] public string IPv6Gateway { get; set; }
        [J("MacAddress")] public string MacAddress { get; set; }
        [J("Networks")] public Networks Networks { get; set; }
    }
}
