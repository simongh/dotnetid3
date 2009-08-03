using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Base text frame implementing encoding
    /// </summary>
    public abstract class BaseTextFrame : BaseFrame
    {
        /// <summary>
        /// Gets or sets the text encoding used in this frame
        /// </summary>
        public TextEncoding Encoding
        {
            get;
            set;
        }

		internal BaseTextFrame(FrameCollection frames)
			: base(frames)
		{ }
    }
}
