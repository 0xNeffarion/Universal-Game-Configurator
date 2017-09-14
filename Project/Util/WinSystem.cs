using Microsoft.Win32;
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Universal_Game_Configurator.Util.Extern;

namespace Universal_Game_Configurator.Util {
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

        public static class Display {

            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPStr)] String lpszDeviceName,
                [MarshalAs(UnmanagedType.U4)] int iModeNum, [In, Out] ref DEVMODE lpDevMode);

            /// <summary>
            /// Refresh rate of the current monitor
            /// </summary>
            /// <returns>Returns current monitor max refresh rate being used or 60 minimum</returns>
            public static int getRefreshRate() {
                DEVMODE dvm = new DEVMODE();

                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
                int maxHz = 0;

                int i = 0;
                while (EnumDisplaySettings(null, i, ref dvm)) {
                    if (dvm.dmPelsWidth == width && dvm.dmPelsHeight == height) {
                        if (dvm.dmDisplayFrequency > maxHz) {
                            maxHz = dvm.dmDisplayFrequency;
                        }
                    }
                    i++;
                }


                return maxHz > 60 ? maxHz : 60;
            }
        }


    }
}
