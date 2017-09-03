using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Universal_Game_Configurator.Theme
{
    public static class ThemeManager
    {
        public static ResourceDictionary GetThemeResourceDictionary()
        {
             Assembly assembly = Assembly.LoadFrom("WPF.Themes.dll");
            string packUri = @"/WPF.Themes;component/ExpressionDark/Theme.xaml";
                return Application.LoadComponent(new Uri(packUri, UriKind.Relative)) as ResourceDictionary;
            
        }

        public static void ApplyTheme(this Application app, string theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary();

            if (dictionary != null)
            {
                app.Resources.MergedDictionaries.Clear();
                app.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        public static void ApplyTheme(this ContentControl control, string theme)
        {
            ResourceDictionary dictionary = ThemeManager.GetThemeResourceDictionary();

            if (dictionary != null)
            {
                control.Resources.MergedDictionaries.Clear();
                control.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        #region Theme

        /// <summary>
        /// Theme Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.RegisterAttached("Theme", typeof(string), typeof(ThemeManager),
                new FrameworkPropertyMetadata((string)string.Empty,
                    new PropertyChangedCallback(OnThemeChanged)));

        /// <summary>
        /// Gets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static string GetTheme(DependencyObject d)
        {
            return (string)d.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Sets the Theme property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetTheme(DependencyObject d, string value)
        {
            d.SetValue(ThemeProperty, value);
        }

        /// <summary>
        /// Handles changes to the Theme property.
        /// </summary>
        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string theme = e.NewValue as string;
            if (theme == string.Empty)
                return;

            ContentControl control = d as ContentControl;
            if (control != null)
            {
                control.ApplyTheme(theme);
            }
        }

        #endregion

    }
}
