using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    [XmlRoot("Configuration")]
    public class Channels
    {
        [XmlArray("Channels")]
        [XmlArrayItem("ChannelInfo")]
        public ChannelInfo[] channelInfo { get; set; }
        public Channels() { }
    }
}
