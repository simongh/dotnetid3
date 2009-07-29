using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    internal static class Util
    {
        public static long ConvertToInt64(byte[] value)
        {
            return ConvertToInt64(value, 0);
        }

        public static long ConvertToInt64(byte[] value, int startIndex)
        {
            return (value[startIndex] * 0x1000) + (value[startIndex + 1] * 0x100) + (value[startIndex + 2] * 0x10) + value[startIndex + 3];
        }

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

        public static byte[] Unsync(BinaryReader reader, int count)
        {
            byte[] result = new byte[count];
            int i = 0;
            bool lastbyte = false;
            while (i < count)
            {
                result[i] = reader.ReadByte();
                if (!lastbyte && result[i] == 0)
                    i++;
                lastbyte = result[i - 1] == 0xff;
            }

            return result;
        }
    }
}
