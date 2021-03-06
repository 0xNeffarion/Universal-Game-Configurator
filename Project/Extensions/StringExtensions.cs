using System;
using System.Text;

namespace Universal_Game_Configurator.Extensions {
    public static class StringExtensions {

        public static int ToInt(this string str) {
            return Convert.ToInt32(str);
        }

        public static long ToLong(this string str) {
            return Convert.ToInt64(str);
        }

        public static bool ToBoolean(this string str) {
            return (str.Trim().ToLower() == "true");
        }

        public static float ToFloat(this string str) {
            return Single.Parse(str);
        }

        public static double ToDouble(this string str) {
            return Convert.ToDouble(str);
        }

        public static Decimal ToDecimal(this string str) {
            return Convert.ToDecimal(str);
        }


    }
}
