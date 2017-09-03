using System;
using System.Collections.Generic;
using System.Windows.Media;
using Universal_Game_Configurator.Configurators;
using System.Xml;
using System.Xml.Serialization;

namespace Universal_Game_Configurator {

    [Serializable]
    [XmlRoot("Game")]
    public class Game {

        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("configurator")]
        public String Type { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("img")]
        public string ImagePath { get; set; }

        [XmlElement("path")]
        public string InstallPath { get; set; }

        [XmlArrayItem("files")]
        public List<String> ConfigFiles { get; set; }

    }
}
