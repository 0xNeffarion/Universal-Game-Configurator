using System;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data {

    [Serializable]
    [XmlRoot("Description")]
    public class Description {

        /// <summary>
        /// Unique ID of the description
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        /// <summary>
        /// Small tag of the description. Used to replace with the text
        /// </summary>
        [XmlElement("Tag")]
        public String Tag { get; set; }

        /// <summary>
        /// Image with the comparison (ex: imgname.jpg). Used to demonstrate differences in graphical effects
        /// </summary>
        [XmlElement("Image")]
        public String Image { get; set; }

        /// <summary>
        /// Full text to describe configuration entry
        /// </summary>
        [XmlElement("Text")]
        public String Text { get; set; }
    }
}
