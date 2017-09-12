using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Databases {

    /// <summary>
    /// Descriptions List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("Database")]
    public class DescriptionsDatabase {

        public List<Description> Descriptions { get; set; }

    }
}
