using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Represents an image of some description
    /// </summary>
    public class AttachedImage : BaseTextFrame
    {
        public override string Name
        {
            get { return "APIC"; }
        }

        internal override string UniqueId
        {
            get
            {
                if (PictureType == PictureType.FileIcon || PictureType == PictureType.OtherFileIcon)
                    return Name + PictureType.ToString("d");

                return Name + PictureType.ToString("d") + MimeType;
            }
        }

        /// <summary>
        /// Gets or sets the mime type of this image. If not specified, image/ is implied.
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the image
        /// </summary>
        public PictureType PictureType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description. There is a limit of 64 chars.
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the binary data
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }

		internal AttachedImage(FrameCollection frames)
			: base(frames)
		{ }

		internal override void ParseBody(byte[] data)
		{
			throw new NotImplementedException();
		}

		protected override byte[] BodyToArray()
		{
			throw new NotImplementedException();
		}
	}
}
