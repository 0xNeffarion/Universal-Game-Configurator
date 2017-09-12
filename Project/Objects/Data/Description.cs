﻿using System;
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
        public int Id { get; set; }

        /// <summary>
        /// Small tag of the description. Used to replace with the text
        /// </summary>
        [XmlElement("tag")]
        public String Tag { get; set; }

        /// <summary>
        /// Image with the comparison (ex: imgname.jpg). Used to demonstrate differences in graphical effects
        /// </summary>
        [XmlElement("image")]
        public String Image { get; set; }

        /// <summary>
        /// Full text to describe configuration entry
        /// </summary>
        [XmlElement("text")]
        public String Text { get; set; }
    }
}