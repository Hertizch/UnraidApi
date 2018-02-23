using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class RestartPolicy
    {
        [J("Name")] public string Name { get; set; }
        [J("MaximumRetryCount")] public long MaximumRetryCount { get; set; }
    }
}
