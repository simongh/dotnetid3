using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// A user defined url
    /// </summary>
    public class UserUrlLink : BaseTextFrame
    {
        public override string Name
        {
            get { return "WXXX"; }
        }

        internal override string UniqueId
        {
            get { return Name + Description; }
        }

        /// <summary>
        /// Gets or sets the description of this url link
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the url
        /// </summary>
        public string Url
        {
            get;
            set;
        }

		internal UserUrlLink(FrameCollection frames)
			: base(frames)
		{ }
    }
}
