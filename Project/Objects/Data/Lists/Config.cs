using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    /// <summary>
    /// Config Entry List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("Configs_List")]
    public class Config {

        [XmlArrayItem("Configs")]
        public List<ConfigEntry> ConfigsList { get; set; }

    }
}
