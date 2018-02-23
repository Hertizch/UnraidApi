using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Port")]
    public class Port
    {
        [XmlElement(ElementName = "HostPort")] public string HostPort { get; set; }
        [XmlElement(ElementName = "ContainerPort")] public string ContainerPort { get; set; }
        [XmlElement(ElementName = "Protocol")] public string Protocol { get; set; }
    }
}
