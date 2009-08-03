using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Holds full text information that doesn't fit in any other frame
    /// </summary>
    public class Comments : LanguageFrame
    {
        public override string Name
        {
            get { return "COMM"; }
        }

        internal override string UniqueId
        {
            get { return Name + Language + Descriptor; }
        }

        /// <summary>
        /// Gets or sets the descriptor
        /// </summary>
        public string Descriptor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text
        {
            get;
            set;
        }

		internal Comments(FrameCollection frames)
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
