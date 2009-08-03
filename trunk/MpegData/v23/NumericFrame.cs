using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    public abstract class NumericFrame : BaseTextFrame
    {
        public virtual int Value
        {
            get;
            set;
        }

		internal NumericFrame(FrameCollection frames)
			: base(frames)
		{ }
    }
}
