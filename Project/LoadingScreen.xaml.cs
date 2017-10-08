using System;
using System.Windows;
using System.Windows.Input;

namespace Universal_Game_Configurator {

    public partial class LoadingScreen : Window {

        private string loadText = "";

        public LoadingScreen(String txt) {
            InitializeComponent();
            loadText = txt;
            pgbar.IsIndeterminate = true;
        }

        public LoadingScreen(String txt, Boolean progress) {
            InitializeComponent();
            loadText = txt;
            pgbar.IsIndeterminate = !progress;
            pgbar.Value = 0;
        }

        public void SetIntermediate(Boolean val) {
            if (val) {
                pgbar.IsIndeterminate = true;
            } else {
                pgbar.IsIndeterminate = false;
                pgbar.Value = 0;
            }
        }

        public void SetProgressValue(double val) {
            pgbar.Value = val;
        }

        public void SetProgressAndText(String text, ref double val) {
            pgbar.Value = val;
            txtTitle.Text = text;
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
