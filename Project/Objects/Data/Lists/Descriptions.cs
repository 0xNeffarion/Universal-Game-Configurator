using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    /// <summary>
    /// Descriptions List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("Descriptions_List")]
    public class Descriptions {

        [XmlArrayItem("Descriptions")]
        public List<Description> DescriptionsList { get; set; }

    }
}
