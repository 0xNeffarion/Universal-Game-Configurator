using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Universal_Game_Configurator.Const;

namespace Universal_Game_Configurator.Converters {
    public class ImageConverter : IValueConverter {

        public static ImageConverter Instance = new ImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                BitmapImage i = new BitmapImage();
                i.BeginInit();
                i.CreateOptions |= BitmapCreateOptions.IgnoreColorProfile;
                i.UriSource = new Uri(Paths.PACKPATH + ((String)value));
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
