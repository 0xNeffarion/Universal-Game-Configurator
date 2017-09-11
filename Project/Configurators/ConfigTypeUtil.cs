using System;
using System.Collections.Generic;

namespace Universal_Game_Configurator {
    public static class ConfigTypesUtil {

        private static Dictionary<ConfigType, Configurator> RetrieveTable(List<String> filesList) {
            Dictionary<ConfigType, Configurator> table = new Dictionary<ConfigType, Configurator>();
            table = new Dictionary<ConfigType, Configurator>() {
                { ConfigType.A, new TypeA(filesList) }
            };

            return table;
        }

        public static Configurator GetConfigurator(ConfigType type, List<String> filesList) {
            var table = RetrieveTable(filesList);
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
