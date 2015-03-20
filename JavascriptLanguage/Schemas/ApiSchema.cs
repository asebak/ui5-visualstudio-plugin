// Created by Ahmad Sebak on 19/03/2015

#region Using

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

#endregion

namespace JavascriptLanguage.Schemas
{
    [XmlRoot("namespace")]
    public class Namespace
    {
        [XmlElement("type")]
        public String Type { get; set; }

        [XmlElement("alias")]
        public String Alias { get; set; }

        [XmlElement("description")]
        public String Description { get; set; }

        [XmlElement("name")]
        public String Name { get; set; }

        [XmlElement("ref")]
        public String Ref { get; set; }

        [XmlElement("children")]
        public NamespaceCollection Children { get; set; }
    }

    [XmlRoot("index")]
    public class NamespaceCollection
    {
        [XmlElement("namespace")]
        public List<Namespace> Items { get; set; }
    }
}