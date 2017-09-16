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
using System.Windows.Forms;
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
using Universal_Game_Configurator.Objects.Data.Helpers;
using Universal_Game_Configurator.Objects.Data.Lesser;
using Universal_Game_Configurator.Objects.ViewModels;

namespace Universal_Game_Configurator {
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelector : Window {

        public GameSelector() {
            InitializeComponent();

            SetupDataContext();
            this.Opacity = 0.00;
            DoubleAnimation anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250 * Settings.AnimationMult));
            this.BeginAnimation(OpacityProperty, anim);
        }

        private void SetupDataContext() {
            this.DataContext = new GameViewModel();
            this.Activate();
        }

        // Adjusts Listview columns on window resize
        private void GamesListView_SizeChanged(object sender, SizeChangedEventArgs e) {
            Double total = GamesListView.ActualWidth;
            GridCol1.Width = (3 * total / 6);
            GridCol2.Width = (2 * total / 6);
            GridCol3.Width = (1 * total / 6);
        }

        private bool FilterSearch(object o) {
            if (txtBoxSearch.Text.Length > 2) {
                Game game = o as Game;
                if (game != null) {
                    return game.Name.ToLower().Contains(txtBoxSearch.Text.ToLower());
                }
            }

            return false;
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e) {
            if (!String.IsNullOrEmpty(txtBoxSearch.Text) && txtBoxSearch.Text.Length > 2) {
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

    }
}
