using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator.Objects.Data.Databases {

    /// <summary>
    /// Games List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("Database")]
    public class GamesDatabase {

        public List<Game> Games { get; set; }

    }
}
