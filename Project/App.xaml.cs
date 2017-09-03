using System;
using System.Management;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic.Devices;
using Universal_Game_Configurator.Theme;
using System.Windows.Media.Animation;

namespace Universal_Game_Configurator {

    public partial class App : Application {

        public App() {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Current.Exit += Current_Exit;

            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline),new FrameworkPropertyMetadata { DefaultValue = 60 }); 
        }

        public bool DoHandle { get; set; }

        protected override void OnStartup(StartupEventArgs e) {
            try {
                var uri = new Uri(@"/WPF.Themes;component/ExpressionDark/Theme.xaml",
                       UriKind.Relative);
                Resources.MergedDictionaries.Add(LoadComponent(uri) as ResourceDictionary);
            } catch (Exception ex) {
                Utilities.showError(null, "Unable to apply WPF Theme.\n" + ex.ToString());
            }
        }

        private void Current_Exit(object sender, ExitEventArgs e) {

        }

        #region Exceptions

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e) {
            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
                Utilities.FastCRC32.CRC32String(e.ToString()), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (1) (Code: " + Utilities.FastCRC32.CRC32String(e.ToString()) + ") : " +
                                  e.Exception.ToString());
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
                Utilities.FastCRC32.CRC32String(e.ToString()), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (2) (Code: " + Utilities.FastCRC32.CRC32String(e.ToString()) + ") : " +
                                  e.Exception.ToString());
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            MessageBox.Show("A Critical error caused the application to crash!\nThe exception has been logged.\nError code: " +
                Utilities.FastCRC32.CRC32String(e.ToString()), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            Console.WriteLine("UNHANDLED EXCEPTION (3) (Code: " + Utilities.FastCRC32.CRC32String(e.ToString()) + ") : " +
                                  e.ExceptionObject.ToString());
        }

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e) {
            Console.WriteLine("UNHANDLED EXCEPTION (4) (Code: " + Utilities.FastCRC32.CRC32String(e.ToString()) + ") : " +
                                  e.Exception.ToString());
        }

        #endregion

    }
}
