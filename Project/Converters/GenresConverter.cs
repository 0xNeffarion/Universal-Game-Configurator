using System;
using System.Globalization;
using System.Windows.Data;

namespace Universal_Game_Configurator {
    public class GenresConverter : IValueConverter {

        public static GenresConverter Instance = new GenresConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            Genres g = (Genres)value;

            if (g == null) {
                return null;
            }

            return g.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
