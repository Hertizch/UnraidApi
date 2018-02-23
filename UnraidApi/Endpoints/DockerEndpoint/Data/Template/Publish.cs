using System.Collections.Generic;
using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Publish")]
    public class Publish
    {
        [XmlElement(ElementName = "Port")] public List<Port> Ports { get; set; }
    }
}
