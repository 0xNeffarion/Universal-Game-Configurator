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
        /// ConfigType enum of configurator to handle config files
        /// </summary>
        [XmlElement("configurator")]
        public ConfigType ConfiguratorType { get; set; }

        /// <summary>
        /// The actual configurator to handle the config files
        /// </summary>
        public Configurator Configurator {
            get {
                return ConfigTypesUtil.GetConfigurator(this.ConfiguratorType, this.ConfigFiles);
            }
        }

        /// <summary>
        /// Game genre
        /// </summary>
        [XmlArrayItem("genres")]
        public Genre[] Genres { get; set; }

        /// <summary>
        /// Game image name (ex: fo4) to show on the game selection
        /// </summary>
        [XmlElement("img")]
        public String ImageName { get; set; }

        /// <summary>
        /// Full path to the game installation directory
        /// </summary>
        public String InstallPath {
            get {
                if (String.IsNullOrEmpty(InstallPath.Trim())) {
                    this.InstallPath = WinSystem.Registry.GetApplicationInstallPath(this.RegistryName);
                    return this.InstallPath;
                } else {
                    return this.InstallPath;
                }
            }

            set { this.InstallPath = value; }
        }

        /// <summary>
        /// Name/Keyword of the game within registry.
        /// Example: Steam App 244850
        /// </summary>
        [XmlElement("reg_name")]
        public String RegistryName { get; set; }

        /// <summary>
        /// List of the paths to the configuration files that the game uses
        /// </summary>
        [XmlArrayItem("files")]
        public List<String> ConfigFiles {

            get { return this.ConfigFiles; }

            set {
                this.ConfigFiles = ConfigUtil.ParseConfigPaths(value, this.InstallPath);
            }
        }

    }
}
