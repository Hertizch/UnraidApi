using J = Newtonsoft.Json.JsonPropertyAttribute;

namespace UnraidApi.Endpoints.DockerEndpoint.Data
{
    public partial class Docker
    {
        public string Name { get; set; }
        [J("running")] public bool Running { get; set; }
        [J("autostart")] public bool Autostart { get; set; }
        [J("icon")] public string Icon { get; set; }
        [J("url")] public string Url { get; set; }
        [J("registry")] public string Registry { get; set; }
        [J("Support")] public string Support { get; set; }
        [J("Project")] public object Project { get; set; }
        [J("updated")] public string Updated { get; set; }
        [J("template")] public string TemplatePath { get; set; }
    }
}
