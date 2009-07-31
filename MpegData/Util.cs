using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    internal static class Util
    {
        /// <summary>
        /// Converts ID3 4 byte numbers into int64 numbers.
        /// </summary>
        /// <param name="value">4 byte number</param>
        /// <returns>int64 int the range 0 - 4,294,967,295</returns>
        public static long ConvertToInt64(byte[] value)
        {
            return ConvertToInt64(value, 0);
        }

        /// <summary>
        /// Converts ID3 4 byte number into int64 numbers.
        /// </summary>
        /// <param name="value">int 64 value</param>
        /// <param name="startIndex">index in the array to start at</param>
        /// <returns>int64 int the range 0 - 4,294,967,295</returns>
        public static long ConvertToInt64(byte[] value, int startIndex)
        {
            if (startIndex + 4 > value.Length)
                throw new ArgumentException("4 bytes are needed for a number.");

            return (value[startIndex] * 0x1000) + (value[startIndex + 1] * 0x100) + (value[startIndex + 2] * 0x10) + value[startIndex + 3];
        }

        /// <summary>
        /// Converts an int in the range 0 - 4,294,967,295 to a ID3 4 byte array
        /// </summary>
        /// <param name="value">Int64 value</param>
        /// <returns>4 byte ID3 number</returns>
        public static byte[] ConvertFromInt64(long value)
        {
            if (value > 0xffff || value < 0)
                throw new ArgumentOutOfRangeException("Only integers in the range 0-0xffff are valid.");

            byte[] result = new byte[4];
            result[0] = (byte)((value & 0xf000) / 0x1000);
            result[1] = (byte)((value & 0xf00) / 0x100);
            result[2] = (byte)((value & 0xf0) / 0x10);
            result[3] = (byte)(value & 0xf);

            return result;
        }

        /// <summary>
        /// Reads a given number of bytes from a stream, removing unsync bytes (0x00). 
        /// Due to unsync bytes more than the requested bytes may be read from the stream.
        /// </summary>
        /// <param name="reader">The stream to read from</param>
        /// <param name="count">number of bytes to read</param>
        /// <returns>The requested bytes</returns>
        public static byte[] Unsync(BinaryReader reader, int count)
        {
            byte[] result = new byte[count];
            int i = 0;
            bool lastbyteff = false;
            while (i < count)
            {
                result[i] = reader.ReadByte();

                if (lastbyteff && result[i] == 0)
                    reader.ReadByte();

                lastbyteff = result[i] == 0xff;
                i++;
            }

            if (lastbyteff && reader.PeekChar() == 0)
                reader.ReadByte();
            
            return result;
        }

        /// <summary>
        /// Reads a single byte from the stream, removing a trialing unsync byte if present.
        /// </summary>
        /// <param name="reader">The stream to read from</param>
        /// <returns>The requested byte</returns>
        public static byte Unsync(BinaryReader reader)
        {
            byte result = reader.ReadByte();

            if (result == 0xff & reader.PeekChar() == 0)
                reader.ReadByte();

            return result;
        }
    }
}
