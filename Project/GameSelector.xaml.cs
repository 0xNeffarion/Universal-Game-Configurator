using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.ViewModels;

namespace Universal_Game_Configurator {

    public partial class GameSelector : Window {

        public GameSelector() {
            InitializeComponent();
            SetupDataContext(null);
            Initialize();
        }

        public GameSelector(GameViewModel savedViewModel) {
            InitializeComponent();
            SetupDataContext(savedViewModel);
            Initialize();
        }

        private void Initialize() {
            this.Opacity = 0.00;
            DoubleAnimation anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250 * Settings.AnimationMult));
            this.BeginAnimation(OpacityProperty, anim);
        }

        private void SetupDataContext(GameViewModel savedVM) {
            GameViewModel vm = savedVM == null ? (new GameViewModel()) : (new GameViewModel(savedVM.Games));
            this.DataContext = vm;
            this.Activate();
        }

        // Adjusts Listview columns on a window resize event
        private void GamesListView_SizeChanged(object sender, SizeChangedEventArgs e) {
            Double total = GamesListView.ActualWidth;
            GridCol1.Width = (3 * total / 6);
            GridCol2.Width = (2 * total / 6);
            GridCol3.Width = (1 * total / 6);
        }

        // Game searching filter
        private Boolean FilterSearch(Object o) {
            Game game = o as Game;
            if (game != null) {
                return game.Name.ToLower().Contains(txtBoxSearch.Text.ToLower());
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
