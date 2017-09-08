using System;
using System.Collections.Generic;

namespace Universal_Game_Configurator {

    public static class ConfigTypes {

        private static Dictionary<String, Configurator> RetrieveTable(List<String> filesList) {
            Dictionary<String, Configurator> table = new Dictionary<String, Configurator>();
            table = new Dictionary<String, Configurator>() {
                { "A", new TypeA(filesList) }
            };

            return table;
        }

        public static Configurator GetConfigurator(String type, List<String> filesList) {
            var table = RetrieveTable(filesList);
            Configurator cfg = null;
            foreach (KeyValuePair<String, Configurator> c in table) {
                if (c.Key.Equals(type)) {
                    cfg = c.Value;
                    break;
                }
            }

            return cfg;
        }

    }
}
