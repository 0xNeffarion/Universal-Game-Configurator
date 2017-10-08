using System;

namespace Universal_Game_Configurator.Const {
    public static class Paths {

        public const String PACKPATH = "pack://application:,,,/";

        private const String DESCRIPTIONS_FILENAME = "descriptions.xml";

        private const String GAMESLIST_FILENAME = "gameslist.xml";

        private const String SETTINGS_FILENAME = "settings.ini";

        public static readonly String APPLICATION_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly String DESCRIPTIONS_PATH = APPLICATION_DIRECTORY + @"\data\text\" + DESCRIPTIONS_FILENAME;

        public static readonly String GAMECONFIGDB_DIRECTORY = APPLICATION_DIRECTORY + @"\data\configs\games\";

        public static readonly String GAMESLIST_PATH = APPLICATION_DIRECTORY + @"\data\games\database\" + GAMESLIST_FILENAME;

        public static readonly String SETTINGS_PATH = APPLICATION_DIRECTORY + @"\" + SETTINGS_FILENAME;

        public static readonly String LOGS_DIRECTORY = APPLICATION_DIRECTORY + @"\logs";

        public static readonly String DATA_DIRECTORY = APPLICATION_DIRECTORY + @"\data";

        public static readonly String DATAVERSION_PATH = DATA_DIRECTORY + @"\VERSION";

        public static readonly String TEMP_DIRECTORY = APPLICATION_DIRECTORY + @"\temp";

        public static readonly String EXTERNAL_DIRECTORY = APPLICATION_DIRECTORY + @"\external";

        public static readonly String GAMEIMAGES_DIRECTORY = APPLICATION_DIRECTORY + @"\data\games\images\icons\";

    }
}
