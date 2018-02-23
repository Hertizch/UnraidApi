using System.Collections.Generic;
using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Environment")]
    public class Environment
    {
        [XmlElement(ElementName = "Variable")] public List<Variable> Variables { get; set; }
    }
}
