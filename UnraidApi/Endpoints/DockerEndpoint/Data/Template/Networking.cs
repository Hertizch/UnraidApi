using System.Collections.Generic;
using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Networking")]
    public class Networking
    {
        [XmlElement(ElementName = "Mode")] public string Mode { get; set; }
        [XmlElement(ElementName = "Publish")] public Publish Publish { get; set; }
    }
}
