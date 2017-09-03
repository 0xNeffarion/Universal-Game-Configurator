using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Universal_Game_Configurator.Configurators.Types {
    /// 
    /// <summary>
    /// NEFFWARE.COM
    /// INI FILES || Type A Configurations ||
    /// 
    /// Example games: Fallout 4, Skyrim, Rainbow Six Siege
    /// </summary>
    /// 

    public class TypeA : Configurator {
        public List<string> Files { get; set; }
        private Utilities.INIFile iniF = new Utilities.INIFile("");

        public TypeA(List<String> files) {
            Files = files;
        }

        public void WriteValue(Config cf) {
            try {
                FileInfo myFile = new FileInfo(Files[cf.FileIndex]);
                myFile.IsReadOnly = false;
            } catch { }

            iniF.path = Files[cf.FileIndex];
            iniF.IniWriteValue(cf.Section, cf.Variable, cf.Value);

        }

        public String ReadValue(string variable, string section = "", short index = 0) {
            iniF.path = Files[index];
            return iniF.IniReadValue(section, variable);
        }

        public String ReadValue(Config cg) {
            iniF.path = Files[cg.FileIndex];
            return iniF.IniReadValue(cg.Section, cg.Variable);
        }
    }
}
