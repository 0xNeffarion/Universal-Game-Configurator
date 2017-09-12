using System;
using System.Globalization;
using System.Windows.Data;
using Universal_Game_Configurator.Objects.Data.Lesser;

namespace Universal_Game_Configurator.Converters {
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
