using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Universal_Game_Configurator.Util.Crypto {
    public static class Hashing {

        public static String FileHash(FileInfo file, HashAlgorithm algo) {
            FileStream filestream = null;
            filestream = new FileStream(file.FullName, FileMode.Open);
            filestream.Position = 0;
            Byte[] hashValue = algo.ComputeHash(filestream);
            String output = BitConverter.ToString(hashValue).Replace("-", String.Empty);
            filestream.Close();
            return output;
        }

        public static String TextHash(String text, HashAlgorithm algo) {
            Byte[] textBytes = Encoding.Default.GetBytes(text);
            Byte[] hashValue = algo.ComputeHash(textBytes);
            String output = BitConverter.ToString(hashValue).Replace("-", String.Empty);
            return output;
        }

        public static String SHA1Hash(String text) {
            return TextHash(text, SHA1.Create());
        }

        public static String SHA1Hash(FileInfo file) {
            return FileHash(file, SHA1.Create());
        }

        public static String SHA2Hash(FileInfo file) {
            return FileHash(file, SHA256.Create());
        }

        public static String SHA2Hash(String text) {
            return TextHash(text, SHA256.Create());
        }

        public static String MD5Hash(FileInfo file) {
            return FileHash(file, MD5.Create());
        }

        public static String MD5Hash(String text) {
            return TextHash(text, MD5.Create());
        }

    }
}
