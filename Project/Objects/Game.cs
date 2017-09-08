using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Game")]
    public class Game {

        /// <summary>
        /// Unique ID of the game
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Complete game name
        /// </summary>
        [XmlElement("name")]
        public String Name { get; set; }

        /// <summary>
        /// Type of configurator to handle config files
        /// </summary>
        [XmlElement("configurator")]
        public String Type { get; set; }

        /// <summary>
        /// Game genre
        /// </summary>
        [XmlElement("genre")]
        public String Genre { get; set; }

        /// <summary>
        /// Game image name (ex: fo4) to show on the game selection
        /// </summary>
        [XmlElement("img")]
        public String ImagePath { get; set; }

        /// <summary>
        /// Full path to the game installation directory
        /// </summary>
        [XmlElement("path")]
        public String InstallPath { get; set; }

        /// <summary>
        /// List of the paths to the configuration files that the game uses
        /// </summary>
        [XmlArrayItem("files")]
        public List<String> ConfigFiles { get; set; }

    }
}
