using System;
using System.Collections.Generic;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator.Configurators.Types {
    /// 
    /// <summary>
    /// INI FILES
    /// 
    /// Example games: Fallout 4, Skyrim, Rainbow Six Siege
    /// </summary>
    /// 

    public class TypeA : Configurator {
        private INIFile iniF;

        public TypeA(List<ConfigFile> Files, String InstallPath) : base(Files, InstallPath) { }

        public override void WriteValue(ConfigEntry cf) {
            iniF = new INIFile(Files[cf.FileIndex]);
            iniF.IniWriteValue(cf, cf.Variable, cf.Value);
        }

        public override string ReadValue(string variable, string section = "", short index = 0) {
            iniF = new INIFile(Files[index]);
            return iniF.IniReadValue(section, variable);
        }

        public override string ReadValue(ConfigEntry cf) {
            iniF = new INIFile(Files[cf.FileIndex]);
            return iniF.IniReadValue(cf.Section, cf.Variable);
        }
    }
}
