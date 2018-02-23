using System.Collections.Generic;
using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Data")]
    public class Data
    {
        [XmlElement(ElementName = "Volume")] public List<Volume> Volumes { get; set; }
    }
}
