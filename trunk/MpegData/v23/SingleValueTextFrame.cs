using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Base text frame for single valued frames
    /// </summary>
    public abstract class SingleValueTextFrame : BaseFrame
    {
        /// <summary>
        /// Gets or sets the text for this frame
        /// </summary>
        public virtual string Value
        {
            get;
            set;
        }

		internal SingleValueTextFrame(FrameCollection frames)
			: base(frames)
		{ }
    }
}
