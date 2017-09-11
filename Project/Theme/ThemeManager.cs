using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Universal_Game_Configurator {
    public static class ThemeManager {

        public const String THEME = "ExpressionDark";
        public const String THEME_PATH = @"/WPF.Themes;component/ExpressionDark/Theme.xaml";

        private static ResourceDictionary GetThemeResourceDictionary() {
            Assembly assembly = Assembly.LoadFrom("WPF.Themes.dll");
            return Application.LoadComponent(new Uri(THEME_PATH, UriKind.Relative)) as ResourceDictionary;
        }

        private static void ApplyTheme(this Application app, string theme) {
            ResourceDictionary dictionary = GetThemeResourceDictionary();

            if (dictionary != null) {
                app.Resources.MergedDictionaries.Clear();
                app.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        private static void ApplyTheme(this ContentControl control, string theme) {
            ResourceDictionary dictionary = GetThemeResourceDictionary();

            if (dictionary != null) {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        public static void ApplyThemeToWindow(this Window window, String themeName) {
            ApplyTheme(window, THEME);
            Application.Current.ApplyTheme(THEME);
        }

        #region Theme

        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(ThemeManager),
                new FrameworkPropertyMetadata((string)string.Empty,
                    new PropertyChangedCallback(OnThemeChanged)));

        public static string GetTheme(DependencyObject d) {
            return (string)d.GetValue(ThemeProperty);
        }

        public static void SetTheme(DependencyObject d, string value) {
            d.SetValue(ThemeProperty, value);
        }

        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
                return;

            ContentControl control = d as ContentControl;
            if (control != null) {
                control.ApplyTheme(theme);
            }
        }

        #endregion

    }
}
