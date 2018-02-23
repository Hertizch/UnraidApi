using UnraidApi.Models.DockerClient;
using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Models
{
    public class Docker
    {
        /// <summary>
        /// Container ID
        /// </summary>
        [J("containerId")] public string ContainerId { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [J("image")] public string Image { get; set; }

        /// <summary>
        /// Created at
        /// </summary>
        [J("createdAt")] public string CreatedAt { get; set; }

        /// <summary>
        /// Uptime
        /// </summary>
        [J("uptime")] public string Uptime { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [J("status")] public string Status { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [J("name")] public string Name { get; set; }

        /// <summary>
        /// Container info
        /// </summary>
        [J("dockerContainer")] public DockerContainer DockerContainer { get; set; }
    }
}
