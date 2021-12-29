using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace ResXapp.Models;

[XmlRoot(ElementName = "resheader")]
public class Resheader
{
    [XmlElement(ElementName = "value")]
    public string Value { get; set; }
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }
}

[XmlRoot(ElementName = "data")]
public class Data
{
    [XmlElement(ElementName = "value")]
    public string Value { get; set; }
    [XmlAttribute(AttributeName = "name")]
    public string Name { get; set; }
    [XmlAttribute(AttributeName = "space", Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string Space { get; set; }
}

[XmlRoot(ElementName = "root")]
public class Root
{
    [XmlElement(ElementName = "resheader")]
    public List<Resheader> Resheader { get; set; }
    [XmlElement(ElementName = "data")]
    public List<Data> Data { get; set; }
}
