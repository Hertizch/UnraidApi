using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class GraphDriver
    {
        [J("Data")] public object Data { get; set; }
        [J("Name")] public string Name { get; set; }
    }
}
