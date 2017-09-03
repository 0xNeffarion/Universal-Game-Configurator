using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {
    [Serializable]
    [XmlRoot("Description")]
    public class Description {

        [XmlElement("id")]
        public int id { get; set; }

        [XmlElement("tag")]
        public String tag { get; set; }

        [XmlElement("image")]
        public String image { get; set; }

        [XmlElement("text")]
        public String text { get; set; }
    }
}
