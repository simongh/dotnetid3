using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Holds an file (general encapsulated object)
    /// </summary>
    public class AttachedFile : BaseTextFrame
    {
        public override string Name
        {
            get { return "GEOB"; }
        }

        internal override string UniqueId
        {
            get { return Name + MimeType + Filename; }
        }

        /// <summary>
        /// Gets or sets the mime type of the object.
        /// </summary>
        public string MimeType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the filename of the object
        /// </summary>
        public string Filename
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of th is object
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

		internal AttachedFile(FrameCollection frames)
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
