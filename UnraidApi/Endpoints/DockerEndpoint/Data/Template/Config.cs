using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Config")]
    public class Config
    {
        [XmlAttribute(AttributeName = "Name")] public string Name { get; set; }
        [XmlAttribute(AttributeName = "Target")] public string Target { get; set; }
        [XmlAttribute(AttributeName = "Default")] public string Default { get; set; }
        [XmlAttribute(AttributeName = "Mode")] public string Mode { get; set; }
        [XmlAttribute(AttributeName = "Description")] public string Description { get; set; }
        [XmlAttribute(AttributeName = "Type")] public string Type { get; set; }
        [XmlAttribute(AttributeName = "Display")] public string Display { get; set; }
        [XmlAttribute(AttributeName = "Required")] public string Required { get; set; }
        [XmlAttribute(AttributeName = "Mask")] public string Mask { get; set; }
        [XmlText] public string Text { get; set; }
    }
}
