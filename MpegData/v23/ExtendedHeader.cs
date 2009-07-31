using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v23
{
    /// <summary>
    /// Extended tag header
    /// </summary>
    public class ExtendedHeader
    {
        /// <summary>
        /// Gets or sets the amount of padding to add to the end of the tag
        /// </summary>
        public long Padding
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the CRC value of the unsynced frame
        /// </summary>
        public byte[] CRC
        {
            get;
            set;
        }

        /// <summary>
        /// Create an extended header from the provided data
        /// </summary>
        /// <param name="value">6 or 10 bytes of extended header data</param>
        internal ExtendedHeader(byte[] value)
            : this()
        {
            bool HasCRC = (value[0] & 0x80) == 0x80;
            if (HasCRC && value.Length == 6)
                throw new ID3Exception("A CRC should be included but was not present.");

            Padding = Util.ConvertToInt64(value, 2);
            CRC = new byte[4];
            Array.Copy(value, 6, CRC, 0, 4);
        }

        /// <summary>
        /// Create an extended header
        /// </summary>
        public ExtendedHeader()
        {
        }

    }
}
