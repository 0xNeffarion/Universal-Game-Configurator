using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Databases {

    /// <summary>
    /// Config Entry List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("ConfigsDatabase")]
    public class ConfigsDatabase {

        [XmlArrayItem("Entry")]
        public List<ConfigEntry> Entries { get; set; }

    }
}
