using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    /// <summary>
    /// Methods for reading a stream looking for tag data
    /// </summary>
    public class TagFactory
    {
        /// <summary>
        /// Finds the version of a tag in a stream
        /// </summary>
        /// <param name="stream">The stream to scan for an ID3 tag</param>
        /// <returns>the major and minor version of the tag</returns>
        public static TagVersion FindTag(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            
			return FindTag(reader);
        }

        /// <summary>
        /// Finds the version of a tag in a stream
        /// </summary>
        /// <param name="reader">A binary reader on the stream to scan for an ID3 tag</param>
        /// <returns>the major and minor version of the tag</returns>
        public static TagVersion FindTag(BinaryReader reader)
        {
            CircularBuffer buffer = new CircularBuffer(reader.ReadBytes(3));
            if (buffer.Capacity != 3)
                return 0;

            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                if (buffer.Peek() == 0x49)
                {
					if (CheckHeader(buffer.ReadAll()))
						return (TagVersion)(20 + reader.ReadByte());
                }

                buffer.Read();
                buffer.Write(reader.ReadByte());
            }

            return 0;
        }

        /// <summary>
        /// Loads a tag from a stream
        /// </summary>
        /// <param name="stream">the stream containing the tag data</param>
        /// <returns>a ID3 tag</returns>
        public static BaseTag GetTag(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);

            BaseTag result = null;
            TagVersion Version = FindTag(reader);
            if (Version == TagVersion.v23)
            {
                result = new v23.Tag();
                result.Parse(reader);
            }

            return result;
        }

        /// <summary>
        /// checks the tag id is "ID3"
        /// </summary>
        /// <param name="data">3 bytes to check</param>
        /// <returns>true if the tag is ID3</returns>
        private static bool CheckHeader(byte[] data)
        {
            return data[0] == 0x49 && data[1] == 0x44 && data[2] == 0x33;
        }

    }
}
