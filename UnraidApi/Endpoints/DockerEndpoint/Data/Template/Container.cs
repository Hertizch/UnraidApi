using System.Collections.Generic;
using System.Xml.Serialization;

namespace UnraidApi.Endpoints.DockerEndpoint.Data.Template
{
    [XmlRoot(ElementName = "Container")]
    public class Container
    {
        [XmlAttribute(AttributeName = "version")] public string Version { get; set; }
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Repository")] public string Repository { get; set; }
        [XmlElement(ElementName = "Registry")] public string Registry { get; set; }
        [XmlElement(ElementName = "Network")] public string Network { get; set; }
        [XmlElement(ElementName = "MyIP")] public string MyIP { get; set; }
        [XmlElement(ElementName = "Privileged")] public bool Privileged { get; set; }
        [XmlElement(ElementName = "Support")] public string Support { get; set; }
        [XmlElement(ElementName = "Project")] public string Project { get; set; }
        [XmlElement(ElementName = "Overview")] public string Overview { get; set; }
        [XmlElement(ElementName = "Category")] public string Category { get; set; }
        [XmlElement(ElementName = "WebUI")] public string WebUI { get; set; }
        [XmlElement(ElementName = "TemplateURL")] public string TemplateURL { get; set; }
        [XmlElement(ElementName = "Icon")] public string Icon { get; set; }
        [XmlElement(ElementName = "ExtraParams")] public string ExtraParams { get; set; }
        [XmlElement(ElementName = "PostArgs")] public string PostArgs { get; set; }
        [XmlElement(ElementName = "DateInstalled")] public string DateInstalled { get; set; }
        [XmlElement(ElementName = "DonateText")] public string DonateText { get; set; }
        [XmlElement(ElementName = "DonateLink")] public string DonateLink { get; set; }
        [XmlElement(ElementName = "DonateImg")] public string DonateImg { get; set; }
        [XmlElement(ElementName = "MinVer")] public string MinVer { get; set; }
        [XmlElement(ElementName = "Description")] public string Description { get; set; }
        [XmlElement(ElementName = "Networking")] public Networking Networking { get; set; }
        [XmlElement(ElementName = "Data")] public Data Data { get; set; }
        [XmlElement(ElementName = "Environment")] public Environment Environment { get; set; }
        [XmlElement(ElementName = "Config")] public List<Config> Config { get; set; }
    }
}
