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

namespace Universal_Game_Configurator.Objects.ViewModels {
    public class ConfigEntryViewModel : BaseViewModel {

        private ObservableCollection<ConfigEntry> _initial_Entries { get; set; }

        private ObservableCollection<Game> _savedGames { get; set; }

        public ObservableCollection<ConfigEntry> Entries { get; set; }

        public Game Game { get; set; }

        public ConfigEntryViewModel(Game game, ObservableCollection<Game> cachedGamesResult) {
            this.Game = game;
            this._savedGames = cachedGamesResult;
            CloseWindowCommand = new BaseParameterCommand<Object>(CloseWindow);
            MinimizeWindowCommand = new BaseParameterCommand<Object>(MinimizeWindow);
            GoBackToSelectorCommand = new BaseParameterCommand<Object>(GoBackToSelector);
            GetEntries();
        }

        public ICommand ResetConfigCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand BackupCommand { get; set; }

        public void GetEntries() {
            Entries = null;
            LoadingScreen loadingScreen = new LoadingScreen("Parsing configuration files...");
            loadingScreen.Show();
            Dispatcher myThread = Dispatcher.CurrentDispatcher;
            Task task = new Task(async () => {
                Entries = new ObservableCollection<ConfigEntry>(ConfigUtil.ParseConfigEntries(Game));
                await myThread.BeginInvoke(DispatcherPriority.Normal, new Action(() => { loadingScreen.Close(); }));
            });

            task.Start();
        }

        #region Window Commands

        public ICommand CloseWindowCommand { get; set; }

        public ICommand MinimizeWindowCommand { get; set; }

        public ICommand GoBackToSelectorCommand { get; set; }

        #region Window Actions/Functions

        public void CloseWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            DoubleAnimation anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200 * Settings.AnimationMult));
            anim.Completed += (s, _) => { win.Close(); Environment.Exit(0); };
            win.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        public void MinimizeWindow(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            win.WindowState = WindowState.Minimized;
        }

        public void GoBackToSelector(Object param) {
            Window win = param as Window;
            if (win == null) {
                return;
            }

            GameSelector gs = new GameSelector();
            DoubleAnimation anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(200 * Settings.AnimationMult));
            anim.Completed += (s, _) => {
                win.Close();
                gs.Show();
                gs.Activate();
            };
            win.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        #endregion

        #endregion

    }
}
