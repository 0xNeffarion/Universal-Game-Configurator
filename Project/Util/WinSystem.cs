using Microsoft.Win32;
using System;

namespace Universal_Game_Configurator {
    public class WinSystem {

        public static class Registry {

            /// <summary>
            /// Provides installed application directory
            /// </summary>
            /// <param name="appName">Full case sensitive application name</param>
            /// <returns>full installation path or null if doesnt exist</returns>
            public static string GetApplicationInstallPath(String appName) {
                string RegPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                RegistryKey key;
                if (Environment.Is64BitOperatingSystem) {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                        .OpenSubKey(RegPath);
                    using (key) {
                        foreach (string subkey_name in key.GetSubKeyNames()) {
                            if (subkey_name == appName) {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name)) {
                                    return subkey.GetValue("InstallLocation").ToString();
                                }
                            }
                        }
                    }
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                        .OpenSubKey(RegPath);
                    using (key) {
                        foreach (string subkey_name in key.GetSubKeyNames()) {
                            if (subkey_name == appName) {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name)) {
                                    return subkey.GetValue("InstallLocation").ToString();
                                }
                            }
                        }
                    }

                } else {
                    key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                        .OpenSubKey(RegPath);
                    using (key) {
                        foreach (string subkey_name in key.GetSubKeyNames()) {
                            if (subkey_name == appName) {
                                using (RegistryKey subkey = key.OpenSubKey(subkey_name)) {
                                    return subkey.GetValue("InstallLocation").ToString();
                                }
                            }
                        }
                    }
                }


                return null;
            }

            /// <summary>
            /// Checks if an application is installed
            /// </summary>
            /// <param name="appName">Full case sensitive application name</param>
            /// <returns>true if exists otherwise false</returns>
            public static bool IsAppicationInstalled(String appName) {
                return GetApplicationInstallPath(appName) != null;
            }

        }


    }
}
