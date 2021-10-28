using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    [XmlRoot(ElementName = "ChannelState")]
    public class StreamsStates
    {
        [XmlElement("Stream")]
        public Stream[] Stream { get; set; }
        public StreamsStates() { }
    }
}
