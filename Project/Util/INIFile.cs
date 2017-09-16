using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Universal_Game_Configurator.Util {

    public class INIFile {

        public String path;

        public INIFile(string INIPath) {
            path = INIPath;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(String section,
            String key, String val, String filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(String section,
            String key, String def, StringBuilder retVal,
            int size, String filePath);

        /// <summary>
        /// Write value into a key inside an ini file
        /// </summary>
        /// <param name="Section">Section inside ini file</param>
        /// <param name="Key">Variable inside section</param>
        /// <param name="Value">Value to assign to the key</param>
        public void IniWriteValue(String Section, String Key, String Value) {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        /// <summary>
        /// Read a key from an ini file
        /// </summary>
        /// <param name="Section">Section inside ini file</param>
        /// <param name="Key">Variable inside section</param>
        /// <returns>String with value of key</returns>
        public String IniReadValue(String Section, String Key) {
            var temp = new StringBuilder(255);
            var i = GetPrivateProfileString(Section, Key, "", temp,
                255, path);
            return temp.ToString();
        }

        internal void IniWriteValue(object section, object variable, object value) {
            throw new NotImplementedException();
        }
    }
}
