using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Holds data that doesn't fit in any other frame
    /// </summary>
    public class PrivateData : BaseFrame
    {
        public override string Name
        {
            get { return "PRIV"; }
        }

        internal override string UniqueId
        {
            get
            {
                return Name + Owner + Data.GetHashCode().ToString();
            }
        }

        /// <summary>
        /// Gets or sets the owner identifier
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data for this frame
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }

		internal PrivateData(FrameCollection frames)
			: base(frames)
		{ }
    }
}
