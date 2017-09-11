using System;
using System.Collections.Generic;

namespace Universal_Game_Configurator {
    /// 
    /// <summary>
    /// INI FILES
    /// 
    /// Example games: Fallout 4, Skyrim, Rainbow Six Siege
    /// </summary>
    /// 

    public class TypeA : Configurator {
        private Utilities.INIFile iniF;

        public TypeA(List<string> Files) : base(Files) {

        }

        public override void WriteValue(ConfigEntry cf) {
            iniF = new Utilities.INIFile(Files[cf.FileIndex]);
            iniF.IniWriteValue(cf, cf.Variable, cf.Value);
        }

        public override string ReadValue(string variable, string section = "", short index = 0) {
            iniF = new Utilities.INIFile(Files[index]);
            return iniF.IniReadValue(section, variable);
        }

        public override string ReadValue(ConfigEntry cf) {
            iniF = new Utilities.INIFile(Files[cf.FileIndex]);
            return iniF.IniReadValue(cf.Section, cf.Variable);
        }
    }
}
