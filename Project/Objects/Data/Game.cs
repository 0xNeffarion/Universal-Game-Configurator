using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator.Objects.Data {

    [Serializable]
    [XmlRoot("Game")]
    public class Game {

        /// <summary>
        /// Unique ID of the game
        /// </summary>
        [XmlElement("UID")]
        public int Id { get; set; }

        /// <summary>
        /// Complete game name
        /// </summary>
        [XmlElement("Name")]
        public String Name { get; set; }

        /// <summary>
        /// ConfigType enum of configurator to handle config files
        /// </summary>
        [XmlElement("Configurator")]
        public ConfigType ConfiguratorType { get; set; }

        /// <summary>
        /// The actual configurator to handle the config files
        /// </summary>
        [XmlIgnore]
        public Configurator Configurator {
            get {
                return ConfigTypesUtil.GetConfigurator(this.ConfiguratorType, this.ConfigFiles, this.InstallPath);
            }
        }

        /// <summary>
        /// Game genre
        /// </summary>
        [XmlArrayItem("Genre")]
        public Genre[] Genres { get; set; }

        /// <summary>
        /// Game image name (ex: fo4) to show on the game selection
        /// </summary>
        [XmlElement("Image")]
        public String ImageName { get; set; }

        /// <summary>
        /// Full path to the game installation directory
        /// </summary>
        [XmlIgnore]
        public String InstallPath {
            get {
                return WinSystem.Registry.GetApplicationInstallPath(this.RegistryName);
            }

            set { this.InstallPath = value; }
        }

        /// <summary>
        /// Name/Keyword of the game within registry.
        /// Example: Steam App 244850
        /// </summary>
        [XmlElement("RegistryName")]
        public String RegistryName { get; set; }

        /// <summary>
        /// List of the config files that the game uses
        /// </summary>
        [XmlElement("ConfigFiles")]
        public List<ConfigFile> ConfigFiles { get; set; }

    }
}
