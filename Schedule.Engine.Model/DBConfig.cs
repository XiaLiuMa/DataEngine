using System;
using System.Xml.Serialization;

namespace Schedule.Engine.Model
{
    public class DataBase
    {
        [XmlElement("guid")]
        public Guid ID { get; set; }

        public string ServerIp { get; set; }

        public string ServerPort { get; set; }

        public bool Default { get; set; }

    }
}
