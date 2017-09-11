using System;
using System.Windows.Media;

namespace Universal_Game_Configurator {

    public class Settings {

        private static Color _UISecondaryColor;
        private static Boolean _UseAnimations;

        public static int AnimationMult {
            get {
                return UseAnimations ? 1 : 0;
            }
        }

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

        public static Boolean UseAnimations {
            get {
                _UseAnimations = Boolean.Parse(GetSetting("EnableAnimations"));
                return _UseAnimations;
            }
            set {
                _UseAnimations = value;
                SetSetting("EnableAnimations", value.ToString());
            }
        }

        private static String GetSetting(String name) {
            INIFile ini = new INIFile(Paths.SETTINGS_PATH);
            return ini.IniReadValue("general", name);
        }

        private static void SetSetting(String name, String value) {
            INIFile ini = new INIFile(Paths.SETTINGS_PATH);
            ini.IniWriteValue("general", name, value);
        }

    }
}
