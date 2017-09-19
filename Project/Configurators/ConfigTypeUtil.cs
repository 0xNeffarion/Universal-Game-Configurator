using System;
using System.Collections.Generic;
using Universal_Game_Configurator.Configurators.Types;
using Universal_Game_Configurator.Objects.Data.Lesser;

namespace Universal_Game_Configurator.Configurators {
    public static class ConfigTypesUtil {

        private static Dictionary<ConfigType, Configurator> RetrieveTable(List<ConfigFile> filesList, String InstallPath) {
            Dictionary<ConfigType, Configurator> table = new Dictionary<ConfigType, Configurator>() {
                { ConfigType.A, new TypeA(filesList, InstallPath) }
            };

            return table;
        }

        public static Configurator GetConfigurator(ConfigType type, List<ConfigFile> filesList, String InstallPath) {
            var table = RetrieveTable(filesList, InstallPath);
            Configurator cfg = null;
            foreach (KeyValuePair<ConfigType, Configurator> c in table) {
                if (c.Key.Equals(type)) {
                    cfg = c.Value;
                    break;
                }
            }

            return cfg;
        }

    }
}
