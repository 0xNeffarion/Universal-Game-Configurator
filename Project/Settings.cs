using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Universal_Game_Configurator {

    public class Settings {

        private static Color _UISecondaryColor;

        public static Color UISecondaryColor {
            get {
                _UISecondaryColor = (Color)ColorConverter.ConvertFromString(GetSetting("UIColor"));
                return _UISecondaryColor;
            }
            set {
                _UISecondaryColor = value;
                SetSetting("UIColor", value.ToString());
            }
        }
    
        private static String GetSetting(String name) {
            Utilities.INIFile ini = new Utilities.INIFile(Utilities.AppDir + @"\settings.ini");
            return ini.IniReadValue("UCG", name);
        }

        private static void SetSetting(String name, String value) {
            Utilities.INIFile ini = new Utilities.INIFile(Utilities.AppDir + @"\settings.ini");
            ini.IniWriteValue("UCG", name, value);
        }

    }
}
