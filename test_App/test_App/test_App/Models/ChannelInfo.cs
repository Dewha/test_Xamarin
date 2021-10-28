using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    public class ChannelInfo 
    {
        [XmlAttribute("Id")]
        public string Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsSoundOn")]
        public string IsSoundOn { get; set; }

        [XmlIgnore]
        public string IsRecordingOn { get; set; }

        [XmlIgnore]
        public string IsSoundOnImage { get; set; }

        [XmlIgnore]
        public string IsRecordingOnImage { get; set; }

        [XmlIgnore]
        public Stream[] Streams { get; set; }

        public ChannelInfo() { }
    }
}
