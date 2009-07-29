using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v23
{
    public class ExtendedHeader
    {
        public long Padding
        {
            get;
            set;
        }

        public byte[] CRC
        {
            get;
            set;
        }

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

        public ExtendedHeader()
        {
        }

    }
}
