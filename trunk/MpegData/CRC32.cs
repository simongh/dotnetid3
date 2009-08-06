using System;
using System.IO;

namespace MpegData
{
    /// <summary>
    /// Calculates a 32bit Cyclic Redundancy Checksum (CRC)
    /// </summary>
    public static class CRC32
    {
        private static readonly UInt32[] crc32Table = new UInt32[256];
        private const Int32 BUFFER_SIZE = 1024;

        static CRC32()
        {
            unchecked
            {
                // Often the polynomial is shown reversed as 0x04C11DB7.
                UInt32 dwPolynomial = 0xEDB88320;

                for (UInt32 i = 0; i < 256; i++)
                {
                    UInt32 dwCrc = i;
                    for (UInt32 j = 8; j > 0; j--)
                    {
                        if ((dwCrc & 1) == 1)
                            dwCrc = (dwCrc >> 1) ^ dwPolynomial;
                        else
                            dwCrc >>= 1;
                    }
                    crc32Table[i] = dwCrc;
                }
            }
        }

        /// <summary>
        /// Returns the CRC32 Checksum of an input stream as a four byte signed integer (Int32).
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>CRC32 Checksum as a four byte signed integer (Int32).</returns>
        public static Int32 CalculateInt32(Stream stream)
        {
            unchecked
            {
                stream.Position = 0;
                UInt32 crc32Result;
                crc32Result = 0xFFFFFFFF;
                Byte[] buffer = new Byte[BUFFER_SIZE];

                Int32 count = stream.Read(buffer, 0, BUFFER_SIZE);
                while (count > 0)
                {
                    for (Int32 i = 0; i < count; i++)
                    {
                        crc32Result = ((crc32Result) >> 8) ^ crc32Table[(buffer[i]) ^ ((crc32Result) & 0x000000FF)];
                    }
                    count = stream.Read(buffer, 0, BUFFER_SIZE);
                }

                return (Int32)~crc32Result;
            }
        }

        /// <summary>
        /// Returns the CRC32 Checksum of a byte array as a four byte signed integer (Int32).
        /// </summary>
        /// <param name="data">The byte array.</param>
        /// <returns>CRC32 Checksum as a four byte signed integer (Int32).</returns>
        public static Int32 CalculateInt32(Byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                return CRC32.CalculateInt32(memoryStream);
            }
        }
    }
}
