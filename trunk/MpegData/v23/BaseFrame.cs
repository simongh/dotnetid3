using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v23
{
    /// <summary>
    /// Base frame for V2.3.0 frames
    /// </summary>
    public abstract class BaseFrame : MpegData.BaseFrame
    {
        /// <summary>
        /// Ascii Encoder for reading frame fields
        /// </summary>
        protected Encoding BaseEncoder;

        /// <summary>
        /// Gets a unique name for this frame
        /// </summary>
        internal virtual string UniqueId
        {
            get { return Name; }
        }

        /// <summary>
        /// Gets or sets whether this frame is encrypted
        /// </summary>
        public bool IsEncrypted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the frame will be compressed
        /// </summary>
        public bool IsCompressed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this frame is in a group
        /// </summary>
        public bool IsInGroup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the frame is read only
        /// </summary>
        public bool IsReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this frame will be preserved when the file is changed
        /// </summary>
        public bool PreserveOnFileChange
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this frame will be preserved when the tag is changed
        /// </summary>
        public bool PreserveOnTagChange
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the encryption method indicator
        /// </summary>
        public byte EncryptionMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the group identifier
        /// </summary>
        public byte GroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the raw data for this frame if it could not be parsed
        /// </summary>
        public byte[] RawData
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the size of the decompressed data
        /// </summary>
        internal long DecompressedSize
        {
            get;
            set;
        }

        public BaseFrame()
        {
            PreserveOnFileChange = true;
            PreserveOnTagChange = true;

            BaseEncoder = Encoding.ASCII;
        }

        /// <summary>
        /// Parses the frame flags
        /// </summary>
        /// <param name="data">2 bytes containg the frame flags</param>
        internal void ReadFlags(byte[] data)
        {
            if (data.Length != 2)
                throw new ID3Exception("The frame flags bytes must be 2 bytes.");

            if ((data[0] & 0x1F) != 0 || (data[1] & 0x1f) != 0)
                throw new ID3Exception("Invalid flags were set on the frame [" + Name + "].");

            PreserveOnTagChange = (data[0] & 0x80) == 0x80;
            PreserveOnFileChange = (data[0] & 0x40) == 0x40;
            IsReadOnly = (data[0] & 0x20) == 0x20;

            IsCompressed = (data[1] & 0x80) == 0x80;
            IsEncrypted = (data[1] & 0x40) == 0x40;
            IsInGroup = (data[1] & 0x20) == 0x20;
        }

        /// <summary>
        /// Imports the binary data into the frame
        /// </summary>
        /// <param name="reader">Binary reader on the stream containing the data for the frame</param>
        /// <param name="isUnsynced">Indicates the binary data has been unsynced</param>
        internal virtual void ImportData(BinaryReader reader, bool isUnsynced)
        {
            long size = Util.ConvertToInt64(isUnsynced ? Util.Unsync(reader, 4) : reader.ReadBytes(4));

            ReadFlags(isUnsynced ? Util.Unsync(reader, 2) : reader.ReadBytes(2));
            if (IsCompressed)
            {
                DecompressedSize = Util.ConvertToInt64(isUnsynced ? Util.Unsync(reader, 4) : reader.ReadBytes(4));
                size -= 4;
            }
            if (IsEncrypted)
            {
                EncryptionMethod = isUnsynced ? Util.Unsync(reader) : reader.ReadByte();
                size--;
            }
            if (IsInGroup)
            {
                GroupId = isUnsynced ? Util.Unsync(reader) : reader.ReadByte();
                size--;
            }

            if (IsCompressed || IsEncrypted)
                StoreRawData(reader, size);
            else
                ReadBody(reader, size);
        }

        /// <summary>
        /// Parses the frame body
        /// </summary>
        /// <param name="reader">Binary reader on the stream containing the data for the frame</param>
        /// <param name="size">amount of data to read from the stream</param>
        protected virtual void ReadBody(BinaryReader reader, long size)
        {
        }

        /// <summary>
        /// Load the frame data when body data could not be parsed at load time.
        /// </summary>
        /// <param name="data">data to load into the frame</param>
        public void ParseRawData(byte[] data)
        {
            if (RawData == null)
                return;

            MemoryStream ms = new MemoryStream(data);
            BinaryReader reader = new BinaryReader(ms);

            ReadBody(reader, ms.Length);

            reader.Close();
            ms.Close();

            RawData = null;
        }

        /// <summary>
        /// Store the body data in the RawData field
        /// </summary>
        /// <param name="reader">Binary reader on the stream containing the data for the frame</param>
        /// <param name="size">amount of data to read from the stream</param>
        private void StoreRawData(BinaryReader reader, long size)
        {
            const int chunksize = 10;

            RawData = new byte[size];

            int i = 0;
            while (i + chunksize < size)
            {
                reader.Read(RawData, i, chunksize);
                i += chunksize;
            }

            reader.Read(RawData, i, (int)(size - i));
        }
    }
}
