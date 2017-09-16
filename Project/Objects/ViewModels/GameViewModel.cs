using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Universal_Game_Configurator.Objects.Commands.Base;
using Universal_Game_Configurator.Objects.Commands.GameSelector;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.ViewModels.Base;

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class GameViewModel : BaseViewModel {

        public ObservableCollection<Game> Games { get; set; }

        public int SelectedGameIndex { get; set; }

        public ICommand ConfigureCommand { get; set; }

        public ICommand GetGamesCommand { get; set; }

        public GameViewModel() {
            ConfigureCommand = new BaseParameterCommand<Object>(Configure);
            GetGamesCommand = new BaseCommand(GetGames);
            MinimizeWindowCommand = new BaseParameterCommand<Object>(MinimizeWindow);
            CloseWindowCommand = new BaseParameterCommand<Object>(CloseWindow);
            GetGames();
        }

        private void Configure(Object param) {
            if (SelectedGameIndex >= 0 && Games != null) {
                if (Games.Count > 0 && Games.Count >= SelectedGameIndex) {
                    MainWindow mw = new MainWindow(Games[SelectedGameIndex] as Game);
                    mw.Show();
                    CloseWindow(param);
                }
            }
        }

        private void GetGames() {
            Games = null;
            LoadingScreen loadingScreen = new LoadingScreen("Detecting installed games...");
            loadingScreen.Show();
            Dispatcher myThread = Dispatcher.CurrentDispatcher;
            Task task = new Task(async () => {
                Games = new ObservableCollection<Game>(GamesUtil.GetInstalledGames());
                await myThread.BeginInvoke(DispatcherPriority.Normal, new Action(() => { loadingScreen.Close(); }));
            });

            task.Start();
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

        #region Window Backing Fields


        #endregion

        #endregion

    }
}
