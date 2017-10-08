using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Universal_Game_Configurator.Objects.Data;
using Universal_Game_Configurator.Objects.ViewModels;
using Universal_Game_Configurator.Theme;
using Color = System.Windows.Media.Color;
using ColorDialog = System.Windows.Forms.ColorDialog;

namespace Universal_Game_Configurator {

    public partial class MainWindow : Window {

        private Color _mainColor = Color.FromArgb(200, 215, 190, 230);

        public MainWindow(Game game, ObservableCollection<Game> cachedgames) {
            InitializeComponent();
            SetupContext(game, cachedgames);
            Initialize(game);
        }

        private void SetupContext(Game game, ObservableCollection<Game> cachedgames) {
            ConfigEntryViewModel vm = new ConfigEntryViewModel(game, cachedgames);
            this.DataContext = vm;
            this.SettingsList.ItemsSource = vm.Entries;

            // Create settings list groups
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(SettingsList.ItemsSource);
            if (view != null) {
                view.SortDescriptions.Clear();
                var sort = new SortDescription("Name", ListSortDirection.Ascending);
                view.SortDescriptions.Add(sort);
                sort = new SortDescription("Group", ListSortDirection.Ascending);
                view.SortDescriptions.Add(sort);
                view.Refresh();
            }

        }

        private void Initialize(Game game) {
            this.Opacity = 0;
            DoubleAnimation anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(250 * Settings.AnimationMult));
            this.BeginAnimation(OpacityProperty, anim);
            this.Title = "Universal Game Configurator - Configurator [" + game.Name + "]";
            this.Activate();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        private void SettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            /*if (SettingsList.Items.Count > 0) {
                if (SettingsList.SelectedIndex != -1) {
                    Config cg = (SettingsList.SelectedItem as Config);
                    if (cg.Description.Length > 0) {
                        if (cg.Description.StartsWith("%") && cg.Description.EndsWith("%")) {
                            SetInformation(cg.Description.Replace("%", ""));
                        } else {
                            textInfoDescription.Text = cg.Description;
                        }
                    }



                    groupBox_setting.Header = "Setting: " + cg?.Name;
                    textInfoName.Text = cg?.Name;
                    if (cg.Default != cg.Value) {
                        CreateValueControl(cg.Type, cg.Value, cg.Range[0], cg.Range[1], cg.Interval, cg.ValueDesc);
                    } else {
                        CreateValueControl(cg.Type, cg.Default, cg.Range[0], cg.Range[1], cg.Interval, cg.ValueDesc);
                    }



                }*/


        }

        private void SetInformation(string tag) {
            /*XDocument doc = XDocument.Load(Utilities.AppDir + @"\data\text\descriptions.xml");
            var root = doc.Descendants("Description");
            string img = "empty.png";
            foreach (var elementRoot in root) {

                string tagS = "";
                string text = "";
                var xElement = elementRoot.Element("Tag");
                if (xElement != null) {
                    tagS = xElement.Value;
                    if (tagS == tag) {
                        if (elementRoot.Element("Image") != null) {
                            img = elementRoot.Element("Image").Value;
                            ImageSource imgS = SourceToImage((@"Resources/Differences/" + img));
                            imgDifference.Source = imgS;
                            imgDifference_tooltip.Source = imgS;
                        }

                        if (elementRoot.Element("Text") != null) {
                            text = elementRoot.Element("Text").Value;
                            textInfoDescription.Text = text;
                        }
                    }



                }
            }
            if (img == "empty.png") {
                imgDifference.Visibility = Visibility.Collapsed;
            } else {
                imgDifference.Visibility = Visibility.Visible;
            }
            */

        }

        private void btnApplySelected_Click(object sender, RoutedEventArgs e) {

        }

        private void ValueControl_ValueChanged(object sender, RoutedEventArgs e) {

        }

        private void btnBackup_Click(object sender, RoutedEventArgs e) {

        }

        private bool FilterSearch(object o) {
            if (txtBoxSearch.Text.Length > 2) {
                var cg = o as ConfigEntry;
                if (cg != null) {
                    if (cg.Name.ToLower().Contains(txtBoxSearch.Text.ToLower())) {
                        return true;
                    }
                }
            }

            return false;
        }

        private void txtBoxSearch_TextChanged(object sender, TextChangedEventArgs e) {
            /*if (txtBoxSearch.Text.Length > 2) {
                if (txtBoxSearch.Text == String.Empty) {
                    SettingsList.Items.Filter = null;
                    return;
                }
                SettingsList.Items.Filter = FilterSearch;
            } else {
                SettingsList.Items.Filter = null;
            }*/
        }

        private void chk_alphabetic_Checked(object sender, RoutedEventArgs e) {
            /* if (this.IsLoaded) {
                 if (chk_alphabetic.IsChecked == true) {

                     var view = (CollectionView)CollectionViewSource.GetDefaultView(SettingsList.ItemsSource);
                     if (view != null) {
                         view.SortDescriptions.Clear();
                         var sort = new SortDescription("Name", ListSortDirection.Ascending);
                         view.SortDescriptions.Add(sort);
                         sort = new SortDescription("Group", ListSortDirection.Ascending);
                         view.SortDescriptions.Add(sort);
                         view.Refresh();

                     }
                     SettingsList.SelectedIndex = 0;

                 } else {
                     var view = (CollectionView)CollectionViewSource.GetDefaultView(SettingsList.ItemsSource);
                     if (view != null) {
                         view.SortDescriptions.Clear();
                         var sort = new SortDescription("Name", ListSortDirection.Descending);
                         view.SortDescriptions.Add(sort);
                         sort = new SortDescription("Group", ListSortDirection.Ascending);
                         view.SortDescriptions.Add(sort);
                         view.Refresh();
                     }
                     SettingsList.SelectedIndex = 0;
                 }
             }*/
        }

        private void chk_alphabetic_Unchecked(object sender, RoutedEventArgs e) {
            /*if (this.IsLoaded) {
                if (chk_alphabetic.IsChecked == false) {
                    var view = (CollectionView)CollectionViewSource.GetDefaultView(SettingsList.ItemsSource);
                    if (view != null) {
                        view.SortDescriptions.Clear();
                        var sort = new SortDescription("Name", ListSortDirection.Ascending);
                        view.SortDescriptions.Add(sort);
                        sort = new SortDescription("Group", ListSortDirection.Descending);
                        view.SortDescriptions.Add(sort);
                        view.Refresh();
                    }
                    SettingsList.SelectedIndex = 0;
                }
            }*/
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void menu_color_Click(object sender, RoutedEventArgs e) {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.ShowHelp = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                _mainColor = Color.FromArgb(200, dialog.Color.R, dialog.Color.G, dialog.Color.B);
                App.Current.Resources["UIColor"] = new SolidColorBrush(_mainColor);
            }
        }
    }

}
