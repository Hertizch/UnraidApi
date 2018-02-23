using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class LogConfig
    {
        [J("Type")] public string Type { get; set; }
        [J("Config")] public ExposedPort Config { get; set; }
    }
}
