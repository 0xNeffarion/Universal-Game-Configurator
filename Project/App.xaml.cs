using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Xml.Serialization;
using Universal_Game_Configurator.Extensions;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Util;
using Universal_Game_Configurator.Theme;
using Universal_Game_Configurator.Util.Logging;
using Universal_Game_Configurator.Util.Tools;
using Universal_Game_Configurator.Updater;

namespace Universal_Game_Configurator {

    public partial class App : Application {

        public App() {
            LogProvider.Initialize();
            Serialization.CreateXmlSerializersCache();

            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            this.ApplyTheme(ThemeManager.THEME);

            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline),
                new FrameworkPropertyMetadata { DefaultValue = WinSystem.Display.getRefreshRate() });

        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e) {
            LogProvider.Close();
        }

        public bool DoHandle { get; set; }

        protected override void OnStartup(StartupEventArgs e) {

        }

        #region Exceptions

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e) {
            String hash = e.ToString().GetHashCode().ToString();

            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
               hash, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (1) (Code: " + hash + ") : " +
                                  e.Exception.ToString());
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            String hash = e.ToString().GetHashCode().ToString();

            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
                hash, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (2) (Code: " + hash + ") : " +
                                  e.Exception.ToString());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            String hash = e.ToString().GetHashCode().ToString();

            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
                (hash), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (3) (Code: " + hash + ") : " +
                                  e.ExceptionObject.ToString());
        }

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e) {
            String hash = e.ToString().GetHashCode().ToString();

            Console.WriteLine("UNHANDLED EXCEPTION (4) (Code: " + hash + ") : " +
                                  e.Exception.ToString());
        }

        #endregion

    }
}
