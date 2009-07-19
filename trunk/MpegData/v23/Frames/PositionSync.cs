using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Identifies how far into the audio stream to start
    /// </summary>
    public class PositionSync : BaseFrame
    {
        private long _Position;

        public override string Name
        {
            get { return "POSS"; }
        }

        /// <summary>
        /// Gets or sets the position format
        /// </summary>
        public TimeStampFormat Format
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the start position
        /// </summary>
        public Int64 Position
        {
            get { return _Position; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Position must be greater than zero.");

                _Position = value;
            }
        }
    }
}
