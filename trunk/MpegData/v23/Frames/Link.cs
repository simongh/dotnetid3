using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Links to a frame to stored externally
    /// </summary>
    public class Link : BaseFrame
    {
        public override string Name
        {
            get { return "LINK"; }
        }

        internal override string UniqueId
        {
            get
            {
                return Name + LinkedFrame + Data;
            }
        }

        /// <summary>
        /// Gets or sets the name of the frame this links to
        /// </summary>
        public string LinkedFrame
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location of the external data
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets additional data needed for the link
        /// </summary>
        public string Data
        {
            get;
            set;
        }

		internal Link(FrameCollection frames)
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
