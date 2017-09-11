using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    /// <summary>
    /// Games List Class. Used for serializing/deserializing
    /// </summary>
    [Serializable]
    [XmlRoot("Games_List")]
    public class Games {

        [XmlArrayItem("Games")]
        public List<Game> GamesList { get; set; }

    }
}
