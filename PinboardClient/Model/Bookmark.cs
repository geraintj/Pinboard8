using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PinboardApi.Model
{
    [XmlRoot("post")]
    public class Bookmark
    {
        [XmlElement("href")]
        public string Url { get; set; }
        [XmlElement("description")]
        public string Title { get; set; }
        [XmlElement("time")]
        public string Time { get; set; }
        [XmlElement("tag")]
        public string TagList { get; set; }
    }
}
