using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Util;
using Universal_Game_Configurator.Util.Logging;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public static class ConfigUtil {

        private static ConfigsDatabase DeserializeDatabase(Game game) {
            return Serialization.Deserialize<ConfigsDatabase>(Paths.GAMECONFIGDB_DIRECTORY + game.Id + ".xml");
        }

        public static ObservableCollection<ConfigEntry> ParseConfigEntries(Game game) {
            LogProvider.Log("Starting config entries deserialization");
            ConfigsDatabase database = DeserializeDatabase(game);
            LogProvider.Log("Finished deserialization");
            ObservableCollection<ConfigEntry> entries = new ObservableCollection<ConfigEntry>(database.Entries);
            Configurator cf = game.Configurator;
            LogProvider.Log("Starting config entries local value parsing");
            for (int i = 0; i < entries.Count; i++) {
                entries[i].Value = cf.ReadValue(entries[i]);
                LogProvider.Log("Entry: " + entries[i].Variable + ". Local Value: " + entries[i].Value);
            }
            LogProvider.Log("Finished parsing");

            return entries;
        }

        public static List<String> ParseConfigPaths(List<ConfigFile> files, String installPath) {
            List<String> parsed = new List<String>();
            foreach (ConfigFile str in files) {
                parsed.Add(GetConfigLocation(str.FakePath, installPath));
            }

            return parsed;
        }

        public static String ParseConfigPath(String path, String installPath) {
            return GetConfigLocation(path, installPath);
        }

        /// <summary>
        /// Provides a complete file path with variable path codes which get translated
        /// </summary>
        /// <param name="pathCode">path with any path code</param>
        /// <param name="gamePath">game executable path</param>
        /// <returns>full complete path to config with all path codes translated</returns>
        private static String GetConfigLocation(String pathCode, String gamePath) {
            StringBuilder basePath = new StringBuilder();
            String[] Dirs = pathCode.Split(new char[] { '\\' });
            foreach (var dir in Dirs) {
                if (dir.Equals("#GAMEDIR#")) {
                    basePath.Append(gamePath);
                } else if (dir.Equals("#MYDOCS#")) {
                    basePath.Append(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                } else if (dir.Equals("#MYGAMES#")) {
                    basePath.Append(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).Append(@"\my games");
                } else if (dir.Equals("#APPDATA#")) {
                    basePath.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                } else if (dir.Equals("#PGFILES#")) {
                    basePath.Append(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                } else if (dir.Equals("#PGFILESX86#")) {
                    basePath.Append(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
                } else if (dir.Equals("#F_FOLDER#") || dir.Equals("#F_FILE#")) {
                    basePath.Append(GetConfigSubs(basePath.ToString(), dir));
                } else {
                    basePath.Append(dir);
                }

                basePath.Append(@"\");
            }

            return basePath.ToString().Substring(0, basePath.Length - 1);
        }

        /// <summary>
        /// Gets first folder or file found of the given path
        /// </summary>
        /// <param name="basePath">Base path to find</param>
        /// <param name="word">Keyword for file or folder</param>
        /// <returns>Base path concatenated with wanted file/folder</returns>
        private static String GetConfigSubs(String basePath, String word) {
            string retStr = basePath;
            if (word.Equals("#F_FOLDER#")) {
                DirectoryInfo dirInfo = new DirectoryInfo(retStr);
                var subDirs = dirInfo.GetDirectories();
                if (subDirs.Length > 0) {
                    retStr += subDirs[0] + @"\";
                }
            } else if (word.Equals("#F_FILE#")) {
                DirectoryInfo dirInfo = new DirectoryInfo(retStr);
                var subFiles = dirInfo.GetFiles();
                if (subFiles.Length > 0) {
                    retStr += subFiles[0];
                }
            }

            return retStr;
        }

    }
}
