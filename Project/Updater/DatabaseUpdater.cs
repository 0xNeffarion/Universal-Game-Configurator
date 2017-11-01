using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Util.Tools;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using Universal_Game_Configurator.Util.Logging;
using Universal_Game_Configurator.Util;
using System.Text;
using Universal_Game_Configurator.Util.Crypto;

namespace Universal_Game_Configurator.Updater {
    public class DatabaseUpdater {

        private const String SEVENZIP_X64 = "579881923A0772DCDF99B85588EFAC1EE072F2CF79010C48B202FC00DE0ED26B";
        private const String SEVENZIP_X86 = "73628E0B1566DE03C0D846CB774BF5AE02CB5C363988CED5BE23AEBA3275B72E";

        private LoadingScreen ldScreen = null;
        private Dispatcher myDispatcher = null;

        public DatabaseUpdater() {
            LogProvider.Log("Initializing Database updater");
            myDispatcher = Dispatcher.CurrentDispatcher;
            ldScreen = new LoadingScreen("Updating database...");
            ldScreen.Show();
            ldScreen.Activate();
        }

        private static Version GetLocalDatabaseVersion() {
            if (Directory.Exists(Paths.DATA_DIRECTORY)) {
                String path = Paths.DATAVERSION_PATH;
                if (File.Exists(path)) {
                    String txt = File.ReadAllText(path, Encoding.UTF8);
                    Version r = null;
                    if (Version.TryParse(txt, out r)) {
                        return r;
                    }
                }
            }

            return new Version(0, 0, 0);
        }

        private static Version GetRemoteDatabaseVersion() {
            Version v = GithubTools.GetLastVersion("UCG-Data");
            return v;
        }


        public static Boolean IsDatabaseOutOfDate() {
            LogProvider.Log("Checking database versions...");
            Version local = GetLocalDatabaseVersion();
            Version remote = GetRemoteDatabaseVersion();

            LogProvider.Log(String.Format("Local: {0} | Remote: {1}", local.ToString(), remote.ToString()));

            return remote > local;
        }

        private async Task DoWork() {
            DeleteOldData();
            String tempfilename = CreateTemp();
            await DownloadDatabase(tempfilename);
            await ExtractDatabase(tempfilename);
            LogProvider.Log("Database updater process complete");
        }

        public static void DeleteDataFolder() {
            LogProvider.Log("Deleting old data folder");
            DirectoryInfo dir = new DirectoryInfo(Paths.DATA_DIRECTORY);
            if (dir.Exists) {
                dir.Delete(true);
                LogProvider.Log("Data folder deleted");
            } else {
                LogProvider.Log("Data folder doesn't exist");
            }
        }

        private void DeleteOldData() {
            ldScreen.SetTitleText("Deleting old data...");
            DatabaseUpdater.DeleteDataFolder();
        }

        private String CreateTemp() {
            CleanTemp();
            LogProvider.Log("Creating random name for temporary file");
            Random rng = new Random();
            String name = "db_" + rng.Next(0, Int32.MaxValue) + ".temp.7z";
            LogProvider.Log("Temporary file name: " + name);

            return Paths.TEMP_DIRECTORY + @"\" + name;
        }

        private void CleanTemp() {
            if (!Directory.Exists(Paths.TEMP_DIRECTORY)) {
                Directory.CreateDirectory(Paths.TEMP_DIRECTORY);
            } else {
                String[] arr = Directory.GetFiles(Paths.TEMP_DIRECTORY);
                if (arr.Length > 0) {
                    LogProvider.Log("Cleaning temporary folder");
                    foreach (String file in arr) {
                        File.Delete(file);
                    }
                }
            }
        }

        private async Task DownloadDatabase(String filename) {
            myDispatcher.Invoke(new Action(() => {
                ldScreen.SetTitleText("Retrieving last release info...");
            }));

            LogProvider.Log("Retrieving database url from github");
            String url = GithubTools.GetLastRelease(GithubTools.DATA_REPONAME);
            WebClient wb = new WebClient();
            wb.DownloadProgressChanged += WebProgressChanged;
            wb.DownloadFileCompleted += WebDownloadCompleted;
            LogProvider.Log("Starting database download (async)");
            using (wb) {
                await wb.DownloadFileTaskAsync(new Uri(url), filename);
            }
        }

        private async Task ExtractDatabase(String filename) {
            String output = Paths.APPLICATION_DIRECTORY;
            String input = filename;
            LogProvider.Log("Starting database extraction...");
            myDispatcher.Invoke(new Action(() => {
                ldScreen.SetTitleText("Beginning database extraction...");
            }));
            await Task.Run(() => ExtractToDir(input, output));
        }

        public async Task UpdateDatabase() {
            await DoWork();
            ldScreen.Close();
            CleanTemp();
        }

        private void ExtractToDir(String inp, String outp) {
            if (!Verify7Zip()) {
                MsgBoxUtil.showError("7Zip Checksum mismatch!");
                return;
            }

            String zPath = Get7ZipPath();
            String args = "x -y -bsp1 -bse1 -bso1 " + inp;
            Regex rex = new Regex(@"(?<p>[0-9]+)%");

            ProcessStartInfo sinfo = new ProcessStartInfo(zPath, args);
            sinfo.WorkingDirectory = outp;
            sinfo.UseShellExecute = false;
            sinfo.RedirectStandardOutput = true;
            sinfo.CreateNoWindow = true;
            sinfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process ps = new Process();
            ps.StartInfo = sinfo;
            ps.EnableRaisingEvents = true;
            ps.OutputDataReceived += (sender, e) => {
                if (!String.IsNullOrEmpty(e.Data)) {
                    Match m = rex.Match(e.Data ?? "");
                    if (m != null && m.Success) {
                        int val = int.Parse(m.Groups["p"].Value);
                        myDispatcher.Invoke(new Action(() => {
                            ldScreen.SetProgressValue(val);
                            ldScreen.SetTitleText("Extracting database... [" + val + "%]");
                        }));
                        LogProvider.Log("Extracting database. Progress: " + val + "%");
                    }
                }
            };


            LogProvider.Log("Database file size: " + Calculations.BytesToKBytes(new FileInfo(inp).Length) + "KBs");
            LogProvider.Log("Launching 7zip executable for extraction.");
            if (ps.Start()) {
                ps.BeginOutputReadLine();
                ps.WaitForExit();
                LogProvider.Log("Database fully extracted.");
            }
        }


        private String Get7ZipPath() {
            String path = Paths.EXTERNAL_DIRECTORY + @"\7zip";
            if (Environment.Is64BitOperatingSystem) {
                path += @"\7zr-x64.exe";
            } else {
                path += @"\7zr-x86.exe";
            }

            return path;
        }

        private Boolean Verify7Zip() {
            String path = Get7ZipPath();
            if (!File.Exists(path)) {
                return false;
            }

            if (Environment.Is64BitOperatingSystem) {
                return Hashing.SHA2Hash(path).Equals(SEVENZIP_X64);
            } else {
                return Hashing.SHA2Hash(path).Equals(SEVENZIP_X86);
            }
        }

        private void WebDownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            if (ldScreen != null) {
                myDispatcher.Invoke(new Action(() => {
                    ldScreen.SetProgressValue(100);
                    ldScreen.SetTitleText("Database download complete");
                }));
                LogProvider.Log("Download complete.");
            }
        }

        private void WebProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            if (ldScreen != null) {
                double progress = e.ProgressPercentage;
                double kbTotal = Calculations.BytesToKBytes(e.TotalBytesToReceive);
                double kbRec = Calculations.BytesToKBytes(e.BytesReceived);

                LogProvider.Log(String.Format("Download in progress. File size: {0} KBs | Downloaded: {1} KBs | {2}%", kbTotal, kbRec, progress));
                myDispatcher.Invoke(new Action(() => {
                    ldScreen.SetProgressValue(progress);
                    ldScreen.SetTitleText("Downloading database... [" + e.ProgressPercentage + "%]");
                }));
            }
        }
    }
}
