using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    [XmlRoot("ArrayOfChannelState")]
    public class ArrayOfChannelState
    {
        [XmlElement("ChannelState")]
        public ChannelState[] ChannelState { get; set; }
        public ArrayOfChannelState() { }
    }
}
