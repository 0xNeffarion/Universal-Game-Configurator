using System;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Lesser {

    [Serializable]
    [XmlRoot("DescriptionEntry")]
    public class DescriptionValue {

        [XmlElement("Value")]
        public String Value { get; set; }

        [XmlElement("Description")]
        public String Description { get; set; }

    }
}
