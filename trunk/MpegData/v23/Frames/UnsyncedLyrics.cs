using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    public class UnsyncedLyrics : Comments
    {
        public override string Name
        {
            get { return "USLT"; }
        }

		internal UnsyncedLyrics(FrameCollection frames)
			: base(frames)
		{ }
    }
}
