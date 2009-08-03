using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MpegData.v23.Frames
{

    /// <summary>
    /// The content type or genre of the recording
    /// </summary>
    public class ContentType : BaseTextFrame
    {
        public override string Name
        {
            get { return "TCON"; }
        }

        /// <summary>
        /// Gets or sets the principle genre
        /// </summary>
        public Genre Genre
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a list of refinements
        /// </summary>
        public List<Genre> Refinements
        {
            get;
            private set;
        }

		public ContentType(FrameCollection frames)
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
