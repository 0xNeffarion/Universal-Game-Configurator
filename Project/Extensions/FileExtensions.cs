using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Game_Configurator.Extensions {
    public static class FileExtensions {

        public static String CRC32Hash(this FileInfo file) {
            byte[] fileBytes = File.ReadAllBytes(file.FullName);
            return Utilities.FastCRC32.CRC32Bytes(fileBytes).ToString();
        }



    }
}
