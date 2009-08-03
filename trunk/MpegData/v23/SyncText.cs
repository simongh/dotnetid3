using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// An individual piece of synced text, usually a syllable
    /// </summary>
    public struct SyncText : IComparable<SyncText>
    {
        private long _TimeStamp;

        /// <summary>
        /// Gets or sets the text for this sync point
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the timestamp for this sync
        /// </summary>
        public long TimeStamp
        {
            get { return _TimeStamp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("A timestamp should be greater than zero.");

                _TimeStamp = value;
            }
        }

        #region IComparable<SyncText> Members

        public int CompareTo(SyncText other)
        {
            return this.TimeStamp.CompareTo(other.TimeStamp);
        }

        #endregion
    }

}
