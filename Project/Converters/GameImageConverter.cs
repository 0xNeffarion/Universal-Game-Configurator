using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Universal_Game_Configurator.Const;

namespace Universal_Game_Configurator.Converters {
    public class GameImageConverter : IValueConverter {
        public static GameImageConverter Instance = new GameImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                BitmapImage i = new BitmapImage();
                i.BeginInit();
                i.CreateOptions |= BitmapCreateOptions.IgnoreColorProfile;
                i.UriSource = new Uri(Paths.GAMEIMAGES_DIRECTORY + ((String)value) + ".jpg");
                i.EndInit();
                return i;
            } catch {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
