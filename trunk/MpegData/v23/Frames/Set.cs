using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Indicates this file is part of a set
    /// </summary>
    public class Set : BaseTextFrame
    {
        public override string Name
        {
            get { return "TPOS"; }
        }

        /// <summary>
        /// Gets or sets the which part this is
        /// </summary>
        public int Part
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the total number of parts. Leave as zero to leave ignore this.
        /// </summary>
        public int Total
        {
            get;
            set;
        }

		internal Set(FrameCollection frames)
			: base(frames)
		{ }
    }
}
