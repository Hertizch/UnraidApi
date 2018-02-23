using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Volume")]
    public class Volume
    {
        [XmlElement(ElementName = "HostDir")] public string HostDir { get; set; }
        [XmlElement(ElementName = "ContainerDir")] public string ContainerDir { get; set; }
        [XmlElement(ElementName = "Mode")] public string Mode { get; set; }
    }
}
