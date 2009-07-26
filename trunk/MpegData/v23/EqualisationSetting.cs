using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// An individual equalisation setting for a given frequency
    /// </summary>
    public struct EqualisationSettting : IComparable<EqualisationSettting>
    {
        private AdjustmentDirection _Direction;
        private short _Frequency;
        private long _Adjustment;

        /// <summary>
        /// Gets or sets the direction of the change
        /// </summary>
        public AdjustmentDirection Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        /// <summary>
        /// Gets or sets the frequency to adjust
        /// </summary>
        public short Frequency
        {
            get { return _Frequency; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Only frequencies in the range 0-32767Hz are valid.");

                _Frequency = value;
            }
        }

        /// <summary>
        /// Gets or sets the adjustment
        /// </summary>
        public long Adjustment
        {
            get { return _Adjustment; }
            set
            {
                if (value < 0)
                {
                    Direction = AdjustmentDirection.Decrease;
                    _Adjustment = value * -1;
                }
                else
                {
                    Direction = AdjustmentDirection.Increase;
                    _Adjustment = value;
                }
            }
        }

        #region IComparable<Frequency> Members

        public int CompareTo(EqualisationSettting other)
        {
            return Frequency.CompareTo(other.Frequency);
        }

        #endregion
    }
}
