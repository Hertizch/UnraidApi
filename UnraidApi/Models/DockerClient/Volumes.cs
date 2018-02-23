using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Volumes
    {
        [J("/config")] public ExposedPort Config { get; set; }
        [J("/data")] public ExposedPort Data { get; set; }
    }
}
