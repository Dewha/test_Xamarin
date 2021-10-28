using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    [XmlRoot("ArrayOfChannelState")]
    public class ChannelState
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("IsRecordingOn")]
        public string IsRecordingOn { get; set; }

        [XmlElement("StreamsStates")]
        public StreamsStates StreamsStates { get; set; }
        public ChannelState() { }
    }
}
