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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Universal_Game_Configurator.Configurators;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.Data.Databases;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Objects.ViewModels;

namespace Universal_Game_Configurator {
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelector : Window {

        public GameSelector() {
            InitializeComponent();



            //SetupDataContext();
            this.Opacity = 0.00;
            DoubleAnimation anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250));
            this.BeginAnimation(OpacityProperty, anim);
        }

        private void SetupDataContext() {
            GameViewModel vm = null;// new GameViewModel();

            this.DataContext = vm;
            vm.CloseWindowAction = new Action(this.Close);
        }

        private void LoadGamesList() {
            //Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate { ldScreen.Close(); }));
        }

        private bool FilterSearch(object o) {
            if (txtBoxSearch.Text.Length > 2) {
                var game = o as Game;
                if (game != null) {
                    return game.Name.ToLower().Contains(txtBoxSearch.Text.ToLower());
                }
            }

            return false;
        }

        private void UpdateColumnsSize() {
            GridCol1.Width = GamesListView.ActualWidth - 170;
        }

        private void GamesListView_SizeChanged(object sender, SizeChangedEventArgs e) {
            UpdateColumnsSize();
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

        private void titleBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                DragMove();
            }
        }


        private void GameSelectionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Closing -= GameSelectionWindow_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromMilliseconds(150));
            anim.Completed += (s, _) => this.Close();
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void btnMinimizeWindow_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e) {
            GamesDatabase gms = new GamesDatabase();
            gms.Games = new List<Game>();
            Game g = new Game() {
                Id = 1,
                Name = "TestName",
                RegistryName = "Regnametest",
                Genres = new Genre[] { Genre.RPG },
                ConfiguratorType = ConfigType.A,
                ConfigFiles = new List<ConfigFile>() { new ConfigFile() { FakePath = "testfakePath" } },
                ImageName = "imagenametest"
            };

            gms.Games.Add(g);
            gms.Games.Add(g);

            XmlSerializer serializer = new XmlSerializer(typeof(GamesDatabase));
            XmlTextWriter writer = new XmlTextWriter(@"C:\Users\Admin\Desktop\file.xml", Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            serializer.Serialize(writer, gms);
            writer.Close();

            this.Close();
        }
    }
}
