using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Base frame for those with language encodings
    /// </summary>
    public abstract class LanguageFrame : BaseTextFrame
    {
        /// <summary>
        /// Gets or sets the 3 character language code
        /// </summary>
        public string Language
        {
            get;
            set;
        }

		internal LanguageFrame(FrameCollection frames)
			: base(frames)
		{ }
    }
}
