using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v23
{
    /// <summary>
    /// A v2.3.0 tag
    /// </summary>
    public class Tag : BaseTag
    {
        /// <summary>
        /// Gets or sets an indication that the tag needs has unsync bytes (0x00) in it
        /// </summary>
        public bool IsUnsynchronised
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this tag should be considered experimental
        /// </summary>
        public bool IsExperimental
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the extended header
        /// </summary>
        public ExtendedHeader ExtendedHeader
        {
            get;
            set;
        }

        /// <summary>
        /// Create a new tag
        /// </summary>
        public Tag()
        {
            Frames = new FrameCollection(this);
        }

        internal override void ImportData(BinaryReader reader)
        {
            ReadHeader(reader);
            Frames.ImportData(reader);
        }

        /// <summary>
        /// Read the tag header from the stream
        /// </summary>
        /// <param name="reader">The stream contianing the data for this tag</param>
        private void ReadHeader(BinaryReader reader)
        {
            if (reader.BaseStream.Position + 5 >= reader.BaseStream.Length)
                throw new ID3Exception("The tag appears to be corrupt.");

            byte flags = reader.ReadByte();

            if ((flags & 0x1f) != 0)
                throw new ID3Exception("The set of flags set on this tag cannot be parsed.");

            this.IsUnsynchronised = (flags & 0x80) == 0x80;
            this.IsExperimental = (flags & 0x20) == 0x20;

            byte[] size = reader.ReadBytes(4);
            this.Size = (size[0] * 512) + (size[1] * 64) + (size[2] * 8) + size[3];
            if (reader.BaseStream.Position + this.Size > reader.BaseStream.Length)
                throw new ID3Exception("The tag length appears to be greater than the length of the stream");

            if ((flags & 0x40) == 0x40)
            {
                int xSize = (int)Util.ConvertToInt64(this.IsUnsynchronised ? Util.Unsync(reader, 4) : reader.ReadBytes(4));
                if (xSize != 6 && xSize != 10)
                    throw new ID3Exception("The extended header is appears to be corrupted.");

                this.ExtendedHeader = new ExtendedHeader(this.IsUnsynchronised ? Util.Unsync(reader, xSize) : reader.ReadBytes(xSize));
            }
        }
    }
}
