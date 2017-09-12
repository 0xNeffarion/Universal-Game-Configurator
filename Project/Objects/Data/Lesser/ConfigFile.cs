using System;
using System.Xml.Serialization;
using Universal_Game_Configurator.Objects.Data.Helpers;

namespace Universal_Game_Configurator.Objects.Data.Lesser {

    [Serializable]
    public class ConfigFile {

        [XmlElement("File")]
        public String FakePath { get; set; }

        public String TruePath(String gameDir) {
            return ConfigUtil.ParseConfigPath(FakePath, gameDir);
        }

    }
}
