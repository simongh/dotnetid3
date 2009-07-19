using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Represents an individual timing code
    /// </summary>
    public struct TimingCode : IComparable<TimingCode>
    {
        private long _TimeStamp;

        /// <summary>
        /// Gets or sets the timing event type
        /// </summary>
        public TimingCodeType EventType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the time stamp in the file. Time stamps are relative to the start of the file.
        /// </summary>
        public long TimeStamp
        {
            get { return _TimeStamp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "Timestamps must be greater than zero.");

                _TimeStamp = value;
            }
        }

        #region IComparable<TimingCode> Members

        public int CompareTo(TimingCode other)
        {
            return TimeStamp.CompareTo(other.TimeStamp);
        }

        #endregion
    }

}