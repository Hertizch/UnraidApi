using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Mount
    {
        [J("Type")] public string Type { get; set; }
        [J("Source")] public string Source { get; set; }
        [J("Destination")] public string Destination { get; set; }
        [J("Mode")] public string Mode { get; set; }
        [J("RW")] public bool Rw { get; set; }
        [J("Propagation")] public string Propagation { get; set; }
    }
}
