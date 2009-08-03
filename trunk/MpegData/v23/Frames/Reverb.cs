using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Stores settings for setting the reverb
    /// </summary>
    public class Reverb : BaseFrame
    {
        public override string Name
        {
            get { return "RVRB"; }
        }

        /// <summary>
        /// Gets or sets the left reverb
        /// </summary>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the right reverb
        /// </summary>
        public int Right
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the lefthand reverb bounces
        /// </summary>
        public byte BouncesLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the righthand reverb bounces
        /// </summary>
        public byte BouncesRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the left to left reverb feedback
        /// </summary>
        public byte FeedbackLeftLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the left to right reverb feedback
        /// </summary>
        public byte FeedbackLeftRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the right to right reverb feedback
        /// </summary>
        public byte FeedbackRightRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the right to left reverb feedback
        /// </summary>
        public byte FeedbackRightLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the left to right premix
        /// </summary>
        public byte PremixLeftToRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the right to left premix
        /// </summary>
        public byte PremixRightToLeft
        {
            get;
            set;
        }

		internal Reverb(FrameCollection frames)
			: base(frames)
		{ }
    }
}
