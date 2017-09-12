using System;
using System.IO;
using Universal_Game_Configurator.Util.Hashing;

namespace Universal_Game_Configurator.Extensions {
    public static class FileExtensions {

        public static String CRC32Hash(this FileInfo file) {
            byte[] fileBytes = File.ReadAllBytes(file.FullName);
            return CRC32.ToHex(fileBytes);
        }

    }
}
