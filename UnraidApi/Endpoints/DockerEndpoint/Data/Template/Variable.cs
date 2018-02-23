using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Environment")]
    public class Variable
    {
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Value")] public string Value { get; set; }
        [XmlElement(ElementName = "Mode")] public string Mode { get; set; }
    }
}
