using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Represents a temp code
    /// </summary>
    public struct TempoCode : IComparable<TempoCode>
    {
        private int _Beat;
        private long _TimeStamp;

        /// <summary>
        /// Gets or sets the beat (BPM) in the range 0-510.
        /// </summary>
        public int Beat
        {
            get { return _Beat; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Beat must be greater than zero.");
                if (value > 510)
                    throw new ArgumentOutOfRangeException("value", "Beat cannot be greater than 510.");

                _Beat = value;
            }
        }

        /// <summary>
        /// Gets or sets the time stamp when the beat starts
        /// </summary>
        public long TimeStamp
        {
            get { return _TimeStamp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Timestamp must be greater than zero.");

                _TimeStamp = value;
            }
        }

        #region IComparable<TempoCode> Members

        public int CompareTo(TempoCode other)
        {
            return this.TimeStamp.CompareTo(other.TimeStamp);
        }

        #endregion
    }
}
