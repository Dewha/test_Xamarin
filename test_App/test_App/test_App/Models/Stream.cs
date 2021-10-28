using System;
using System.Xml.Serialization;

namespace test_App.Models
{
    [Serializable]
    [XmlRoot(ElementName = "StreamsStates")]
    public class Stream
    {
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("State")]
        public string State { get; set; }
        public Stream() { }

        public Stream(string type, string state)
        {
            Type = type;
            State = state;
        }
    }
}
