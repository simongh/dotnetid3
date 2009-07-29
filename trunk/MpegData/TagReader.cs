using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    public class TagReader
    {
        public static int FindTag(Stream stream)
        {
            BinaryReader reader = null;
            try
            {
                reader = new BinaryReader(stream);
                return FindTag(reader);
            }
            finally
            {
                reader.Close();
            }
        }

        public static int FindTag(BinaryReader reader)
        {
            CircularBuffer buffer = new CircularBuffer(reader.ReadBytes(3));
            if (buffer.Capacity != 3)
                return 0;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                if (buffer.Read() == 0x49)
                {
                    if (CheckHeader(buffer.ReadAll()))
                        return 20 + reader.ReadByte();
                }

                buffer.Write(reader.ReadByte());
            }

            return 0;
        }

        public static BaseTag GetTag(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);

            int Version = FindTag(reader);
            if (Version == 23)
            {
                return new v23.Tag(reader);
            }

            return null;
        }

        private static bool CheckHeader(byte[] data)
        {
            return data[0] == 0x49 && data[1] == 0x44 && data[2] == 0x33;
        }
    }
}
