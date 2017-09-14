using System;
using System.Collections.Generic;
using System.IO;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Util;

namespace Universal_Game_Configurator.Objects.Data.Helpers {
    public static class ConfigUtil {

        public static ConfigsDatabase DeserializeDatabase(Game game) {
            String path = Paths.GAMECONFIGDB_DIRECTORY + game.Id + ".xml";

            return Serialization.Deserialize<ConfigsDatabase>(path);
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
            string basePath = "";
            String[] Dirs = pathCode.Split(new char[] { '\\' });
            foreach (var dir in Dirs) {
                if (dir.Equals("#GAMEDIR#")) {
                    basePath += gamePath;
                } else if (dir.Equals("#MYDOCS#")) {
                    basePath += Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                } else if (dir.Equals("#MYGAMES#")) {
                    basePath += Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\my games";
                } else if (dir.Equals("#APPDATA#")) {
                    basePath += Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                } else if (dir.Equals("#PGFILES#")) {
                    basePath += Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                } else if (dir.Equals("#PGFILESX86#")) {
                    basePath += Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                } else if (dir.Equals("#F_FOLDER#") || dir.Equals("#F_FILE#")) {
                    basePath += GetConfigSubs(basePath, dir);
                } else {
                    basePath += dir;
                }

                basePath += @"\";
            }

            return basePath.Substring(0, basePath.Length - 1);
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
