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
		public event EventHandler<CompressFrameEventArgs> CompressFrame;
		public event EventHandler<EncryptFrameEventArgs> EncryptFrame;
		
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
        /// Gets or sets the size of the decompressed data
        /// </summary>
        internal long DecompressedSize
        {
            get;
            set;
        }

		public BaseFrame(FrameCollection frames)
			: base()
		{
			Frames = frames;

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
        /// Parses the frame body
        /// </summary>
        /// <param name="reader">Binary reader on the stream containing the data for the frame</param>
        /// <param name="size">amount of data to read from the stream</param>
        internal virtual void ParseBody(byte[] data)
        {
        }

        internal virtual void ToBinary(BinaryWriter writer)
        {
			byte[] buffer = BodyToArray();

            writer.Write(BaseEncoder.GetBytes(this.Name));
            
            Size = 0;
			if (IsCompressed)
			{
				buffer = OnCompressFrame(buffer);
			}
			if (IsEncrypted)
			{
				buffer = OnEncryptFrame(buffer);
			}
            if (IsInGroup)
                Size++;
            Size += buffer.Length;

            writer.Write(Util.ConvertFromInt64(Size));
            byte flags = PreserveOnTagChange ? (byte)0x80 : (byte)0x0;
            flags += PreserveOnFileChange ? (byte)0x40 : (byte)0;
            flags += IsReadOnly ? (byte)0x20 : (byte)0x0;
            writer.Write(flags);

			flags = IsCompressed ? (byte)0x80 : (byte)0;
			flags += IsEncrypted ? (byte)0x40 : (byte)0;
			flags += IsInGroup ? (byte)0x20 : (byte)0;
			writer.Write(flags);

			if (IsCompressed)
				writer.Write(Util.ConvertFromInt64(DecompressedSize));
			if (IsEncrypted)
				writer.Write(EncryptionMethod);
			if (IsInGroup)
				writer.Write(GroupId);

			writer.Write(buffer);
        }

		protected virtual byte[] BodyToArray()
		{
			throw new NotImplementedException();
		}

		protected byte[] OnCompressFrame(byte[] buffer)
		{
			if (CompressFrame == null && IsCompressed)
				throw new ID3Exception("The frame is flagged as compressed, but nothing has been set to handle this.");

			Size += 4;
			DecompressedSize = buffer.Length;

			CompressFrameEventArgs e = new CompressFrameEventArgs(buffer);

			if (CompressFrame != null)
				CompressFrame(this, e);

			if (e.Clear)
			{
				IsCompressed = false;
				Size -= 4;

				return buffer;
			}
			else
				return e.Data;
		}

		protected byte[] OnEncryptFrame(byte[] buffer)
		{
			if (EncryptFrame == null && IsEncrypted)
				throw new ID3Exception("The frame is flagged as encrypted, but nothing has been set to handle this.");

			Size++;
			EncryptFrameEventArgs e = new EncryptFrameEventArgs(buffer, this.EncryptionMethod);

			if (EncryptFrame != null)
				EncryptFrame(this, e);

			if (e.Clear)
			{
				IsEncrypted = false;
				Size--;

				return buffer;
			}
			else
				return e.Data;
		}

	}
}
