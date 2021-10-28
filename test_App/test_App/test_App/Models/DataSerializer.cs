using System;
using System.IO;
using System.Xml.Serialization;

namespace test_App.Models
{
    public class DataSerializer
    {
        public object XmlDeserialize(Type dataType, string xmlAsString)
        {
            string XmlСorrected = xmlAsString.Substring(xmlAsString.IndexOf("<?xml"));
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            TextReader textReader = new StringReader(XmlСorrected);
            object obj = xmlSerializer.Deserialize(textReader);
            textReader.Close();
            return obj;
        }
    }
}
