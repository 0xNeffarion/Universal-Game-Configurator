using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Universal_Game_Configurator.Configurators.Types {
    /// 
    /// <summary>
    /// NEFFWARE.COM
    /// LUA FILES || Type B Configurations ||
    /// 
    /// Example games: Company of Heroes 2
    /// </summary>
    /// 

    public class TypeC : Configurator {
        public List<string> Files { get; set; }

        public void WriteValue(Config cf) {
            String[] fileExp = Regex.Split(File.ReadAllText(Files[cf.FileIndex]), Environment.NewLine);
            for (int i = 0; i < fileExp.Length; i++) {

            }
        }

        public string ReadValue(string variable, string section = "", short index = 0) {
            String[] fileExp = Regex.Split(File.ReadAllText(Files[index]), "},");
            for (int i = 0; i < fileExp.Length; i++) {
                string vari = "";
                string val = "";
                if (fileExp[i].Contains("setting = ") && fileExp[i].Contains("value = ")) {
                    String[] txtLines = Regex.Split(fileExp[i], Environment.NewLine);
                    foreach (string line in txtLines) {
                        if (line.Contains("setting = ")) {
                            if (Regex.Matches(line, "(\"\\w+\")")[0].Success) {
                                vari = Regex.Matches(line, "(\"\\w+\")")[0].Value.Replace("\"", "");
                                if (vari != variable) {
                                    break;
                                }
                            }
                        } else if (line.Contains("value = ")) {
                            int rem = line.IndexOf(" = ", StringComparison.Ordinal);
                            val = line.Substring(line.Length - rem - 3).Replace(",", "");
                            return val;
                        }
                    }
                }
            }

            return "";
        }

        public string ReadValue(Config cg) {
            throw new NotImplementedException();
        }
    }
}
