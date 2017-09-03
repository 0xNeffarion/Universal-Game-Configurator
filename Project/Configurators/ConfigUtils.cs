using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Configurators.Types;

namespace UGCEditor.Configurators {
    public static class ConfigUtils {

        public static Configurator GetConfiguratorByString(String name, List<String> list) {
            Dictionary<String, Configurator> types;

            types = new Dictionary<String, Configurator>(){
                    {"A", new TypeA(list)},
                    {"01", new Type01()}
                };

            Configurator cg = null;
            foreach(KeyValuePair<String,Configurator> c in types) {
                if (c.Key.Equals(name)) {
                    cg = c.Value;
                    break;
                }
            }

            return cg;
        }

    }
}
