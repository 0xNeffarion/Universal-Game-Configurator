using System;
using System.IO;

namespace Universal_Game_Configurator {
    public static class FileExtensions {

        public static String CRC32Hash(this FileInfo file) {
            byte[] fileBytes = File.ReadAllBytes(file.FullName);
            return Utilities.FastCRC32.CRC32Bytes(fileBytes).ToString("X");
        }

    }
}
