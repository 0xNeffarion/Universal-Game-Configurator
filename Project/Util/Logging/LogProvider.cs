using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Universal_Game_Configurator.Const;

namespace Universal_Game_Configurator.Util.Logging {
    public static class LogProvider {

        private static String FilePath = null;
        private static FileStream LogStream = null;
        private static readonly int BUFFER_SIZE = 256;

        public static void Initialize() {
            FilePath = GetFilePath();
            CreateStream();
        }

        public static void Close() {
            if (LogStream != null) {
                LogStream.Flush();
                LogStream.Close();
            }
        }

        private static String GetFilePath() {
            DirectoryInfo dir = new DirectoryInfo(Paths.LOGS_DIRECTORY);

            if (!dir.Exists) {
                dir.Create();
            }

            FileInfo[] files = dir.GetFiles("logfile_*.txt");

            if (files.Length > 5) {
                for (int i = 0; i < files.Length; i++) {
                    files[i].Delete();
                }

                files = dir.GetFiles("logfile_*.txt");
            }

            int inc = 0, max = 0;

            if (files != null && files.Length > 0) {
                for (int i = 0; i < files.Length; i++) {
                    String name = files[i].Name;
                    int num = 0;
                    if (!Int32.TryParse(Regex.Replace(name, @"[^\d]", ""), out num)) {
                        continue;
                    }

                    if (num > max) {
                        max = num;
                    }
                }

                inc = max + 1;
            }

            return Paths.LOGS_DIRECTORY + @"\logfile_" + inc + ".txt";
        }

        private static void CreateStream() {
            LogStream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read, BUFFER_SIZE);
        }

        private static void AppendLine(String str) {
            if (LogStream == null || String.IsNullOrEmpty(str)) {
                return;
            }

            String output = str + Environment.NewLine;
            Byte[] bytes = Encoding.UTF8.GetBytes(output);

            LogStream.Write(bytes, 0, bytes.Length);
        }

        private static String GetTime() {
            return DateTime.Now.ToString("HH:mm:ss.fff");
        }

        public static void Log(String str) {
            String time = GetTime();
            String outStr = str.Trim();

            String output = $"[{time}] - {outStr}";
            AppendLine(output);
            Console.WriteLine(output);
        }

        public static void Log(Exception e) {
            Log(e.ToString());
        }

    }
}
