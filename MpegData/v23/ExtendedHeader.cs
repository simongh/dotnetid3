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
		public event EventHandler<CRCEventArgs> CalculateCRC;

		private byte[] _CRC;

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
        public bool HasCRC
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
            HasCRC = (value[0] & 0x80) == 0x80;
            if (HasCRC && value.Length == 6)
                throw new ID3Exception("A CRC should be included but was not present.");

            Padding = Util.ConvertToInt64(value, 2);
            _CRC = new byte[4];
            Array.Copy(value, 6, _CRC, 0, 4);
        }

        /// <summary>
        /// Create an extended header
        /// </summary>
        public ExtendedHeader()
        {
        }

		internal byte[] ToArray()
		{
			byte[] result = null;
			if (HasCRC)
			{
				result = new byte[10];
				result[3] = 6;
			}
			else
			{
				result = new byte[14];
				result[3] = 10;
			}

			result[4] = HasCRC ? (byte)0x80 : (byte)0;
			Util.ConvertFromInt64(Padding).CopyTo(result, 6);

			if (_CRC != null)
				_CRC.CopyTo(result, 9);

			return result;
		}

		internal virtual void OnCalculateCRC(byte[] data)
		{
			CRCEventArgs e = new CRCEventArgs(data);
			if (CalculateCRC != null)
				CalculateCRC(this, e);

			if (e.CRC != null && e.CRC.Length != 4)
				throw new ID3Exception("The Tag CRC should be 4 bytes long.");

			_CRC = e.CRC;
		}

    }
}
