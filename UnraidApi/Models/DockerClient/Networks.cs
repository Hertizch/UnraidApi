using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models.DockerClient
{
    public class Networks
    {
        [J("bridge")] public Bridge Bridge { get; set; }
    }
}
