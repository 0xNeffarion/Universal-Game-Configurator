using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Configurators.Types;
using Universal_Game_Configurator.Theme;

namespace Universal_Game_Configurator {
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelector : Window {

        private List<Game> _gamesList = new List<Game>();
        private Dictionary<string, Configurator> Types;
        private LoadingScreen ldScreen;

        public GameSelector() {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void LoadGamesList() {
            String path = Utilities.AppDir + @"\data\games\database\gameslist.xml";

            Games games;
            XmlSerializer xs = new XmlSerializer(typeof(Game));
            using (var sr = new StreamReader(path)) {
             //   games = (Games)xs.Deserialize(sr);
            }

           // _gamesList = games.games_list;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate { ldScreen.Close(); }));
        }

        private bool FilterSearch(object o) {
            if (txtBoxSearch.Text.Length > 2) {
                var game = o as Game;
                if (game != null) {
                    if (game.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())) {
                        return true;
                    }
                }
            }

            return false;
        }

        private void UpdateColumnsSize() {
            GridCol1.Width = GamesListView.ActualWidth - 160 - 10;
        }

        private void GetInstalledGames() {
            GamesListView.ItemsSource = null;
            ldScreen = new LoadingScreen("Detecting and loading installed games...");
            Thread th = new Thread(new ThreadStart(LoadGamesList));
            th.Start();
            ldScreen.ShowDialog();
            GamesListView.ItemsSource = _gamesList;
        }

        private void GameSelectionWindow_Loaded(object sender, RoutedEventArgs e) {
            windowTitle.Text = this.Title;
            ThemeManager.ApplyTheme(this, "ExpressionDark");
            Application.Current.ApplyTheme("ExpressionDark");
            var anim = new DoubleAnimation(1, (Duration)TimeSpan.FromMilliseconds(250));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
            GetInstalledGames();
        }

        private void GamesListView_SizeChanged(object sender, SizeChangedEventArgs e) {
            UpdateColumnsSize();
        }

        private void imgNext_MouseDown(object sender, MouseButtonEventArgs e) {
            if (sender != null) {
                Game gm = (Game)(sender as Image).DataContext;
                if (gm != null) {
                    MainWindow mw = new MainWindow(gm);
                    mw.Show();
                    this.Close();
                }
            }
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e) {
            if (txtBoxSearch.Text.Length > 2) {
                if (txtBoxSearch.Text == String.Empty) {
                    GamesListView.Items.Filter = null;
                    return;
                }
                GamesListView.Items.Filter = FilterSearch;
            } else {
                GamesListView.Items.Filter = null;
            }
        }

        private void imgRefresh_MouseDown(object sender, MouseButtonEventArgs e) {
            GetInstalledGames();
        }

        private void titleBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void GamesListView_KeyDown(object sender, KeyEventArgs e) {
            if (GamesListView.SelectedIndex != -1) {
                if (e.Key == Key.Enter) {
                    var image = GamesListView.SelectedItem as Image;
                    if (image != null) {
                        Game gm = (Game)image.DataContext;
                        if (gm != null) {
                            this.Close();

                            MainWindow mw = new MainWindow(gm);
                            mw.Show();

                        }
                    }
                }
            }
        }

        private void GameSelectionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Closing -= GameSelectionWindow_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(200));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
