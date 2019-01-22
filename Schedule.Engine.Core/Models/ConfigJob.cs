using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Engine.Core.Models
{
    public class ConfigJob
    {
        public Guid ID { get; set; }

        public bool state { get; set; }

        public string Expresstion { get; set; }

        public string typeName { get; set; }

        public string Conn { get; set; }
    }
}
