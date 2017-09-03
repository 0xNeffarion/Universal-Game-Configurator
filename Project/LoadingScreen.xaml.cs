using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Universal_Game_Configurator {
    /// <summary>
    /// Interaction logic for LoadingScreen.xaml
    /// </summary>
    public partial class LoadingScreen : Window {

        private string loadText = "";

        public LoadingScreen(string txt) {
            InitializeComponent();
            loadText = txt;
        }

        private void loadingWindow_Loaded(object sender, RoutedEventArgs e) {
            txtTitle.Text = loadText;
        }

        public void SetTitleText(string txt) {
            txtTitle.Text = txt;
        }

        private void loadBorder_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();

            }
        }
    }
}
