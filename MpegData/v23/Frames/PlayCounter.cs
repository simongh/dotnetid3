using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Counter of how many times the file has been played
    /// </summary>
    public class PlayCounter : BaseFrame
    {
        public override string Name
        {
            get { return "PCNT"; }
        }

        /// <summary>
        /// Gets or sets the play count
        /// </summary>
        public long Counter
        {
            get;
            set;
        }
    }
}
