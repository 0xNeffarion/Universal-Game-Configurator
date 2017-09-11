using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Universal_Game_Configurator {
    [CLSCompliant(false)]
    public class CRC32 : HashAlgorithm {

        /// <summary>Polynomial used to generate the checksum table.</summary>
        private const uint Polynomial = 0xEDB88320;

        /// <summary>Seed used to generate the hash code.</summary>
        private const uint Seed = 0xFFFFFFFF;

        /// <summary>Checksum table of 8-bit encoded values.</summary>
        private static readonly uint[] Table = InitializeTable(Polynomial);

        /// <summary>Computed hash code.</summary>
        private uint hash;

        /// <summary>Initializes a new instance of the <see cref="Crc32" /> class.</summary>
        public CRC32() {
            this.HashSizeValue = 32;
            this.Initialize();
        }

        /// <summary>Initializes the instance.</summary>
        public override void Initialize() {
            this.hash = Seed;
        }

        /// <summary>Routes data written to the object into the hash algorithm for computing the hash.</summary>
        /// <param name="data">The input to compute the hash code for.</param>
        /// <param name="start">The offset into the byte array from which to begin using data.</param>
        /// <param name="size">The number of bytes in the byte array to use as data.</param>
        protected override void HashCore(byte[] data, int start, int size) {
            this.State = 1;
            for (int i = start; i < size; i++) this.hash = (this.hash >> 8) ^ Table[data[i] ^ (this.hash & 0xFF)];
        }

        /// <summary>Finalizes the hash computation after the last data is processed by the cryptographic stream object.</summary>
        /// <returns>The computed hash code.</returns>
        protected override byte[] HashFinal() {
            this.HashValue = BitConverter.GetBytes(~this.hash);
            this.State = 0;
            return this.HashValue;
        }

        /// <summary>Converts a byte array to a hexadecimal string.</summary>
        /// <param name="data">Data to convert.</param>
        /// <returns>Hexadecimal string corresponding to the specified data.</returns>
        public static string ToHex(byte[] data) {
            var builder = new StringBuilder();
            foreach (var item in data) builder.Append(item.ToString("x2", CultureInfo.InvariantCulture));
            return builder.ToString();
        }

        /// <summary>Converts a byte array to unsigned 32-bit integer.</summary>
        /// <remarks>The array passed as a parameter must have a maximum length of 4 elements.<remarks>
        /// <param name="data">Data to convert.</param>
        /// <returns>Unsigned 32-bit integer corresponding to the specified data.</returns>
        public static uint ToUInt32(byte[] data) {
            return uint.Parse(ToHex(data), NumberStyles.HexNumber);
        }

        /// <summary>Initializes the checksum table from the specified polynomial.</summary>
        /// <param name="polynomial">Polynomial used to generate the checksum table.</param>
        /// <returns>Checksum table of 8-bit encoded values.</returns>
        private static uint[] InitializeTable(uint polynomial) {
            var table = new uint[256];

            for (int i = 0; i < table.Length; i++) {
                var value = (uint)i;

                for (int j = 0; j < 8; j++) {
                    if ((value & 1) == 1) value = (value >> 1) ^ polynomial;
                    else value >>= 1;
                }

                table[i] = value;
            }

            return table;
        }
    }
}

