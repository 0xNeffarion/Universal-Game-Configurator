using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Universal_Game_Configurator.Util {

    public static class Utilities {

        public static String MD5File(String filename) {
            using (var md5 = MD5.Create()) {
                using (var stream = File.OpenRead(filename)) {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

    }
}