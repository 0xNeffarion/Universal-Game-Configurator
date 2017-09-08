using System;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {
    [Serializable]
    [XmlRoot("Description")]
    public class Description {

        /// <summary>
        /// Unique ID of the description
        /// </summary>
        [XmlElement("id")]
        public int id { get; set; }

        /// <summary>
        /// Small tag of the description. Used to replace with the text
        /// </summary>
        [XmlElement("tag")]
        public String tag { get; set; }

        /// <summary>
        /// Image with the comparison (ex: imgname.jpg). Used to demonstrate differences in graphical effects
        /// </summary>
        [XmlElement("image")]
        public String image { get; set; }

        /// <summary>
        /// Full text to describe configuration entry
        /// </summary>
        [XmlElement("text")]
        public String text { get; set; }
    }
}
