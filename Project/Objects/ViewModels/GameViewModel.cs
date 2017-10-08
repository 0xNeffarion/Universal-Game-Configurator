using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.ViewModels.Base;
using Universal_Game_Configurator.Util.Logging;
using Universal_Game_Configurator.Updater;
using System.IO;
using Universal_Game_Configurator.Const;
using Universal_Game_Configurator.Util;
using System.Windows.Controls;
using System.Windows.Media;

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class GameViewModel : BaseViewModel {

        public ObservableCollection<Game> Games { get; set; }

        public int SelectedGameIndex { get; set; }

        public ICommand ConfigureCommand { get; set; }

        public GameViewModel(ObservableCollection<Game> gamesSaved) {
            Initialize();
            this.Games = gamesSaved;
        }

        public GameViewModel() {
            Initialize();
            GetUpdatesAndGames();
        }

        private void Initialize() {
            ConfigureCommand = new BaseParameterCommand<Object>(Configure);
            MinimizeWindowCommand = new BaseParameterCommand<Object>(MinimizeWindow);
            CloseWindowCommand = new BaseParameterCommand<Object>(CloseWindow);
        }

        private void Configure(Object param) {
            if (SelectedGameIndex >= 0 && Games != null) {
                if (Games.Count > 0 && Games.Count >= SelectedGameIndex) {
                    MainWindow mw = new MainWindow(Games[SelectedGameIndex] as Game, this.Games);
                    mw.Show();
                    CloseWindow(param);
                }
            }
        }

        public void GetGames() {
            Games = null;
            LoadingScreen loadingScreen = new LoadingScreen("Detecting installed games...");
            loadingScreen.Show();
            loadingScreen.Activate();
            Dispatcher myThread = Dispatcher.CurrentDispatcher;
            Task task = new Task(async () => {
                Games = new ObservableCollection<Game>(GamesUtil.GetInstalledGames());
                await myThread.BeginInvoke(DispatcherPriority.Normal, new Action(() => { loadingScreen.Close(); }));
            });

            task.Start();
        }

        public async void GetUpdatesAndGames() {
            Games = null;
            if (DatabaseUpdater.IsDatabaseOutOfDate()) {
                await UpdateDatabase();
            }
            GetGames();
        }

        public void ForceUpdatesAndGames() {
            if (MsgBoxUtil.showConfirmation("Are you sure you want to force database updates?\nThe application will need to restart", "Force update")
                == MessageBoxResult.Yes) {
                if (File.Exists(Paths.DATAVERSION_PATH)) {
                    File.Delete(Paths.DATAVERSION_PATH);
                }
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                Application.Current.Shutdown();
            }
        }

        public void OpenDatabaseEditor(object sender, MouseButtonEventArgs e) {
            if (sender == null) {
                return;
            }

            Image img = (Image)sender;
            var parent = VisualTreeHelper.GetParent(img);
            while (!(parent is Window)) {
                parent = VisualTreeHelper.GetParent(parent);
            }

            // TODO: MAKE STUFF
            Window wn = (Window)parent;
            wn.WindowState = WindowState.Minimized;

        }

        private async Task<Boolean> UpdateDatabase() {
            DatabaseUpdater dbu = new DatabaseUpdater();
            try {
                await dbu.UpdateDatabase();
                return true;
            } catch (Exception e) {
                LogProvider.Log(e);
                return false;
            }
        }

        #region Window Commands

        public ICommand CloseWindowCommand { get; set; }

        public ICommand MinimizeWindowCommand { get; set; }

        #region Window Actions/Functions

        public void CloseWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            DoubleAnimation anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200 * Settings.AnimationMult));
            anim.Completed += (s, _) => win.Close();
            win.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        public void MinimizeWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            win.WindowState = WindowState.Minimized;
        }

        #endregion

        #endregion

    }
}
