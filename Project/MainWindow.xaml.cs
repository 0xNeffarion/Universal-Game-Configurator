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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.Toolkit;
using Color = System.Windows.Media.Color;
using ColorDialog = System.Windows.Forms.ColorDialog;
using WindowState = System.Windows.WindowState;

namespace Universal_Game_Configurator {

    public partial class MainWindow : Window {

        private readonly Dictionary<string, Configurator> Types;
        private Color _mainColor = Color.FromArgb(200, 215, 190, 230);
        private UIElement _currentControl;
        private int _gameId = 0;
        private GridViewColumn _tempColumn;
        private byte _numCols = 3;
        private string _gamePath = null;
        private ObservableCollection<Config> _configs = new ObservableCollection<Config>();
        private readonly Configurator _currentConfigurator;
        private LoadingScreen _ldScreen;

        public MainWindow(Game game) {
            _currentConfigurator = ConfigTypes.GetConfigurator(game.Type, game.ConfigFiles);
            _gamePath = game.InstallPath;
            _gameId = game.Id;
            InitializeComponent();
            App.Current.Resources["UIColor"] = new SolidColorBrush(Colors.MediumPurple);
            this.Opacity = 0;
            this.Title = "Universal Game Configurator - Configurator [" + game.Name + "]";
        }

        private void listView_SizeChanged(object sender, SizeChangedEventArgs e) {
            if (this.IsLoaded) {
                RefreshListSize();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            windowTitle.Text = this.Title;
            this.ApplyThemeToWindow(ThemeManager.THEME);
            var anim = new DoubleAnimation(1, (Duration)TimeSpan.FromMilliseconds(300));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
            RefreshListSize();
            _configs.Clear();
            SettingsList.ItemsSource = null;

            _ldScreen = new LoadingScreen("Loading game configs...");
            Thread th = new Thread(new ThreadStart(LoadConfigs));
            th.Start();
            _ldScreen.ShowDialog();

        }

        private void RefreshListSize() {
            ConfigCol1.Width = ((SettingsList.ActualWidth / _numCols) - 8.00);
            ConfigCol2.Width = ((SettingsList.ActualWidth / _numCols) - 8.00);
            ConfigCol3.Width = ((SettingsList.ActualWidth / _numCols) - 8.00);
        }

        private void LoadConfigs() {
            XDocument doc = XDocument.Load(Utilities.AppDir + @"\data\configs\games\" + _gameId + ".xml");
            var root = doc.Descendants("Config");
            int id = 0;
            short index = 0;
            string section = "";
            string variable = "";
            string name = "";
            string desc = "";
            int tp = 0;
            string defVal = "";
            bool isFixed = false;
            Decimal rangeMin = 0;
            double interval = 0;
            Decimal rangeMax = 0;
            Groups gp = Groups.Gameplay;



            LoadLocalConfigs();


            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate {
                SettingsList.ItemsSource = _configs;
                var view = (CollectionView)CollectionViewSource.GetDefaultView(SettingsList.ItemsSource);
                if (view != null) {
                    view.GroupDescriptions.Clear();
                    var groupDescription = new PropertyGroupDescription("Group");
                    view.GroupDescriptions.Add(groupDescription);


                    view.SortDescriptions.Clear();
                    var sort = new SortDescription("Group", ListSortDirection.Descending);
                    view.SortDescriptions.Add(sort);
                    sort = new SortDescription("Name", ListSortDirection.Descending);
                    view.SortDescriptions.Add(sort);
                }
                _ldScreen.Close();
                SettingsList.SelectedIndex = 0;

            }));

        }

        private void CreateValueControl(int type, object defaultVal, Decimal rangeMin = -1, Decimal rangeMax = -1, double interval = -1, Dictionary<String, String> valdescriptions = null) {
            ValueContainer.Children.Clear();

            switch (type) {
                case 0:  // Normal Integer TextBox

                    IntegerUpDown control = new IntegerUpDown();

                    if (rangeMax == -1 && rangeMin == -1) {
                        control.Maximum = Int32.MaxValue;
                        control.Minimum = Int32.MinValue;
                    } else {
                        control.Maximum = Convert.ToInt32(rangeMax);
                        control.Minimum = Convert.ToInt32(rangeMin);
                    }

                    if (defaultVal != null) {
                        int temp = 0;

                        try {
                            temp = (int)defaultVal;
                        } catch { }
                        control.Value = temp;
                    }

                    _currentControl = control;
                    ValueContainer.Children.Add(_currentControl);
                    control.ValueChanged += ValueControl_ValueChanged;


                    break;
                case 1:  // Normal String TextBox

                    TextBox control2 = new TextBox();
                    if (defaultVal != null) {
                        String temp = "";

                        try {
                            temp = (string)defaultVal;
                        } catch { }
                        control2.Text = temp;
                    }


                    control2.FontSize = 13;
                    control2.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    control2.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    _currentControl = control2;
                    ValueContainer.Children.Add(_currentControl);
                    control2.TextChanged += ValueControl_ValueChanged;

                    break;
                case 2:  // Normal Double Textbox

                    DecimalUpDown control3 = new DecimalUpDown();
                    if (rangeMax == -1 && rangeMin == -1) {
                        control3.Maximum = Decimal.MaxValue;
                        control3.Minimum = Decimal.MinValue;
                    } else {
                        control3.Maximum = rangeMax;
                        control3.Minimum = rangeMin;
                    }

                    if (defaultVal != null) {
                        Decimal temp = 0;

                        try {
                            temp = (Decimal)defaultVal;
                        } catch { }
                        control3.Value = temp;
                    }

                    _currentControl = control3;
                    ValueContainer.Children.Add(_currentControl);
                    control3.ValueChanged += ValueControl_ValueChanged;
                    break;
                case 3:  // Normal Boolean ComboBox

                    ComboBox control4 = new ComboBox();
                    control4.Tag = "BoolNormal";
                    ComboBoxItem tItem = new ComboBoxItem();
                    ComboBoxItem fItem = new ComboBoxItem();

                    tItem.Content = "Disabled";
                    fItem.Content = "Enabled";

                    control4.Items.Add(tItem);
                    control4.Items.Add(fItem);
                    control4.SelectedIndex = 0;
                    if (defaultVal != null) {
                        if (((bool)defaultVal)) {
                            control4.SelectedIndex = 1;
                        } else {
                            control4.SelectedIndex = 0;
                        }
                    }
                    control4.SetValue(BorderBrushProperty, new SolidColorBrush(Color.FromRgb(155, 155, 155)));
                    control4.SetValue(BorderThicknessProperty, new Thickness(1, 1, 1, 1));

                    _currentControl = control4;
                    ValueContainer.Children.Add(_currentControl);
                    control4.SelectionChanged += ValueControl_ValueChanged;
                    break;
                case 4:  // YesNo Boolean ComboBox

                    ComboBox control5 = new ComboBox();
                    control5.Tag = "BoolYesNo";
                    ComboBoxItem yItem = new ComboBoxItem();
                    ComboBoxItem nItem = new ComboBoxItem();

                    yItem.Content = "Disabled";
                    nItem.Content = "Enabled";

                    control5.Items.Add(yItem);
                    control5.Items.Add(nItem);
                    control5.SelectedIndex = 0;
                    string df = defaultVal as string;
                    if (df != null) {
                        if (df == "Yes") {
                            control5.SelectedIndex = 1;
                        } else {
                            control5.SelectedIndex = 0;
                        }
                    }
                    control5.SetValue(BorderBrushProperty, new SolidColorBrush(Color.FromRgb(155, 155, 155)));
                    control5.SetValue(BorderThicknessProperty, new Thickness(1, 1, 1, 1));

                    _currentControl = control5;
                    ValueContainer.Children.Add(_currentControl);
                    control5.SelectionChanged += ValueControl_ValueChanged;
                    break;
                case 5:  // 1/0 Boolean ComboBox

                    ComboBox control6 = new ComboBox();
                    control6.Tag = "BoolOneZero";
                    ComboBoxItem oItem = new ComboBoxItem();
                    ComboBoxItem zItem = new ComboBoxItem();

                    oItem.Content = "Disabled";
                    zItem.Content = "Enabled";

                    control6.Items.Add(oItem);
                    control6.Items.Add(zItem);
                    control6.SelectedIndex = 0;
                    if (defaultVal != null) {
                        int? bl = defaultVal.ToString().ToInt();
                        if (bl == 1) {
                            control6.SelectedIndex = 1;
                        } else {
                            control6.SelectedIndex = 0;
                        }
                    }
                    control6.SetValue(BorderBrushProperty, new SolidColorBrush(Color.FromRgb(155, 155, 155)));
                    control6.SetValue(BorderThicknessProperty, new Thickness(1, 1, 1, 1));

                    _currentControl = control6;
                    ValueContainer.Children.Add(_currentControl);
                    control6.SelectionChanged += ValueControl_ValueChanged;
                    break;
                case 6:  // Double Slider
                    Slider control7 = new Slider();
                    control7.AutoToolTipPrecision = 4;
                    if (interval > 0) {
                        control7.TickFrequency = interval;
                        control7.IsSnapToTickEnabled = true;
                        control7.TickPlacement = TickPlacement.BottomRight;
                    }
                    control7.Orientation = Orientation.Horizontal;
                    control7.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft;
                    if (rangeMax == -1 && rangeMin == -1) {
                        control7.Maximum = short.MaxValue;
                        control7.Minimum = short.MinValue;
                    } else {
                        control7.Maximum = (double)rangeMax;
                        control7.Minimum = (double)rangeMin;
                    }

                    if (defaultVal != null) {
                        control7.Value = Convert.ToDouble(defaultVal);
                    }


                    _currentControl = control7;
                    ValueContainer.Children.Add(_currentControl);
                    control7.ValueChanged += ValueControl_ValueChanged;
                    break;
                case 7:  // Integer Slider
                    Slider control8 = new Slider();
                    control8.AutoToolTipPrecision = 0;
                    if (interval > 0) {
                        control8.TickFrequency = interval;
                        control8.IsSnapToTickEnabled = true;
                        control8.TickPlacement = TickPlacement.BottomRight;
                    }
                    control8.Orientation = Orientation.Horizontal;
                    control8.AutoToolTipPlacement = AutoToolTipPlacement.TopLeft;
                    if (rangeMax == -1 && rangeMin == -1) {
                        control8.Maximum = short.MaxValue;
                        control8.Minimum = short.MinValue;
                    } else {
                        control8.Maximum = (int)rangeMax;
                        control8.Minimum = (int)rangeMin;
                    }

                    if (defaultVal != null) {
                        control8.Value = Convert.ToInt32(defaultVal);
                    }


                    _currentControl = control8;
                    ValueContainer.Children.Add(_currentControl);
                    control8.ValueChanged += ValueControl_ValueChanged;
                    break;
                case 8:  // ComboBox values with descriptions
                    ComboBox control9 = new ComboBox();
                    control9.Tag = "ComboValDesc";

                    ComboBoxItem cb = null;
                    foreach (var val in valdescriptions) {
                        cb = new ComboBoxItem();
                        cb.Content = val.Value;
                        cb.Tag = val.Key;
                        control9.Items.Add(cb);

                        if ((cb.Tag as string) == (defaultVal as string)) {
                            control9.SelectedItem = cb;
                        }
                    }
                    control9.SetValue(BorderBrushProperty, new SolidColorBrush(Color.FromRgb(155, 155, 155)));
                    control9.SetValue(BorderThicknessProperty, new Thickness(1, 1, 1, 1));
                    _currentControl = control9;
                    ValueContainer.Children.Add(_currentControl);
                    control9.SelectionChanged += ValueControl_ValueChanged;

                    break;
                default:
                    break;
            }
        }

        private void LoadLocalConfigs() {
            try {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate {
                    _ldScreen.SetTitleText("Reading & parsing local configurations...");
                }));
                if (_currentConfigurator.Files.Any(x => File.Exists(x) == false)) {
                    Utilities.showError(this,
                        "The game configuration files are missing from you computer.\nRun the game at least once before using this tool");
                    Environment.Exit(0);
                }

                foreach (var config in _configs) {
                    //nfig.Value = _currentConfigurator.ReadValue(config);
                }
            } catch (Exception) { }
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
            XDocument doc = XDocument.Load(Utilities.AppDir + @"\data\text\descriptions.xml");
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


        }

        private void ApplySettings() {
            foreach (var cg in _configs) {
                //   _currentConfigurator.WriteValue(cg);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e) {
            GameSelector gs = new GameSelector();
            this.Close();
            gs.Show();
        }

        private ImageSource SourceToImage(string source) {
            var bm = new BitmapImage(new Uri("pack://application:,,,/" + source, UriKind.Absolute));
            return bm;
        }

        private void btnApplySelected_Click(object sender, RoutedEventArgs e) {
            if (System.Windows.MessageBox.Show(this, "Are you certain you want to save all modified settings?",
                    "Confirm settings", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                try {
                    ApplySettings();
                    Utilities.showMessage(this, "Settings applied.", "Settings");
                } catch (Exception ex) {
                    Utilities.showError(this, "Error occured:\n" + ex.ToString());
                }
            }
        }

        private void ValueControl_ValueChanged(object sender, RoutedEventArgs e) {
            if (sender != null) {

                if (SettingsList.SelectedIndex == -1 || SettingsList.SelectedItem == null) {
                    return;
                }
                try {
                    ListViewItem item = SettingsList.ItemContainerGenerator.ContainerFromItem(SettingsList.SelectedItem) as ListViewItem;
                    item.Background = new SolidColorBrush(_mainColor);
                } catch (NullReferenceException) { }

                var cg = SettingsList.SelectedItem as ConfigEntry;




            }
        }

        private void btnBackup_Click(object sender, RoutedEventArgs e) {
            string bk = ".backup";
            if (Utilities.showConfirmation(this, "Overwrite any backups created for this game?", "Backups") == MessageBoxResult.No) {
                Random rng = new Random();
                bk = ".backup_" + rng.Next(0, 99999).ToString();
            }

            try {
                StringBuilder sb = new StringBuilder();
                int n = 1;
                string str = "";
                foreach (var file in _currentConfigurator.Files) {
                    if (File.Exists(file + bk) && bk == ".backup") {
                        str = "Previous backup files have been overwritten";
                    }
                    File.Copy(file, file + bk, true);
                    string tmp = file;
                    sb.AppendLine("• FILE " + n + " •");
                    if (file.Length > 55) {
                        tmp = file.Remove(0, 15);
                        tmp = "..." + tmp;
                    }
                    sb.AppendLine(tmp);
                    sb.AppendLine("Copied to ↓");
                    sb.AppendLine(tmp + bk);
                    sb.AppendLine("");
                    n++;
                }

                Utilities.showMessage(this, "Backup successfull!\nFiles copied:\n\n" + sb.ToString() + "\n" + str, "Backup");
            } catch (Exception) {
                Utilities.showError(this, "Error copying files");
            }
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
            if (txtBoxSearch.Text.Length > 2) {
                if (txtBoxSearch.Text == String.Empty) {
                    SettingsList.Items.Filter = null;
                    return;
                }
                SettingsList.Items.Filter = FilterSearch;
            } else {
                SettingsList.Items.Filter = null;
            }
        }

        private void chk_alphabetic_Checked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
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
            }
        }

        private void chk_alphabetic_Unchecked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
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
            }
        }

        private void chk_default_Checked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
                if (chk_default.IsChecked == true) {

                    SettingsGridView.Columns.Insert(2, _tempColumn);
                    _numCols = 3;
                    RefreshListSize();
                }
            }
        }

        private void chk_default_Unchecked(object sender, RoutedEventArgs e) {
            if (this.IsLoaded) {
                if (chk_default.IsChecked == false) {
                    _tempColumn = SettingsGridView.Columns[2];
                    SettingsGridView.Columns.RemoveAt(2);

                    _numCols = 2;
                    RefreshListSize();
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                this.DragMove();
            }
        }

        private void mainWindow_Closing(object sender, CancelEventArgs e) {
            Closing -= mainWindow_Closing;
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

        private void btnReset_Click(object sender, RoutedEventArgs e) {

            foreach (var item in SettingsList.Items) {
                ListViewItem it = SettingsList.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
                it.Background = System.Windows.Media.Brushes.Transparent;
            }
            SettingsList.ItemsSource = null;
            _configs.Clear();
            LoadConfigs();
            Utilities.showMessage(this, "Settings reset complete", "Settings reset");
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e) {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void menu_color_Click(object sender, RoutedEventArgs e) {
            ColorDialog dialog = new ColorDialog();
            dialog.FullOpen = true;
            dialog.ShowHelp = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                _mainColor = Color.FromArgb(200, dialog.Color.R, dialog.Color.G, dialog.Color.B);
            }

            for (int i = 0; i < SettingsList.Items.Count; i++) {
                var item = SettingsList.Items[i] as ConfigEntry;
                if (item.IsChanged) {
                    ListViewItem it = SettingsList.ItemContainerGenerator.ContainerFromItem(SettingsList.Items[i]) as ListViewItem;
                    if (it != null) {
                        it.Background = new SolidColorBrush(_mainColor);
                    }

                }
            }
            App.Current.Resources["UIColor"] = new SolidColorBrush(_mainColor);
        }
    }

}
