using System;
using System.Windows.Media;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator {

    public class Settings {

        private static readonly INIFile ini = new INIFile(Paths.SETTINGS_PATH);
        private static Color _UISecondaryColor;
        private static Boolean _UIUseAnimations;
        private static Boolean _UIUseHardwareAcceleration;
        private static Boolean _UIUseIncreasedFPS;
        private static String _EditorPathGames;
        private static String _EditorPathConfig;
        private static String _EditorPathDescription;

        public static String EditorPathDescription {
            get {
                _EditorPathDescription = GetSetting("Editor", "DescPath");
                return _EditorPathGames;
            }
            set {
                _EditorPathDescription = value;
                SetSetting("Editor", "DescPath", value);
            }
        }

        public static String EditorPathGames {
            get {
                _EditorPathGames = GetSetting("Editor", "GamesPath");
                return _EditorPathGames;
            }
            set {
                _EditorPathGames = value;
                SetSetting("Editor", "GamesPath", value);
            }
        }

        public static String EditorPathConfig {
            get {
                _EditorPathConfig = GetSetting("Editor", "ConfigPath");
                return _EditorPathConfig;
            }
            set {
                _EditorPathConfig = value;
                SetSetting("Editor", "ConfigPath", value);
            }
        }

        public static Double AnimationMult {
            get {
                return _UIUseAnimations ? 1 : 0.001;
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

        public static Boolean UIUseAnimations {
            get {
                _UIUseAnimations = (GetSetting("EnableAnimations").ToLower().Equals("true"));
                return _UIUseAnimations;
            }
            set {
                _UIUseAnimations = value;
                SetSetting("EnableAnimations", value.ToString());
            }
        }

        public static Boolean UIUseHardwareAcceleration {
            get {
                _UIUseHardwareAcceleration = (GetSetting("UseHardwareAcc").ToLower().Equals("true"));
                return _UIUseHardwareAcceleration;
            }
            set {
                _UIUseHardwareAcceleration = value;
                SetSetting("UseHardwareAcc", value.ToString());
            }
        }

        public static Boolean UIUseIncreasedFPS {
            get {
                _UIUseIncreasedFPS = (GetSetting("UseIncreasedFPS").ToLower().Equals("true"));
                return _UIUseIncreasedFPS;
            }
            set {
                _UIUseIncreasedFPS = value;
                SetSetting("UseIncreasedFPS", value.ToString());
            }
        }

        private static String GetSetting(String name) {
            return ini.IniReadValue("Main", name);
        }

        private static void SetSetting(String name, String value) {
            ini.IniWriteValue("Main", name, value);
        }

        private static String GetSetting(String section, String name) {
            return ini.IniReadValue(section, name);
        }

        private static void SetSetting(String section, String name, String value) {
            ini.IniWriteValue(section, name, value);
        }

    }
}
