using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Volume properties for a speaker
    /// </summary>
    public struct VolumeAdjustment
    {
        private long _RelativeChange;
        private long _Peak;

        /// <summary>
        /// Gets or set the direction of the change
        /// </summary>
        public AdjustmentDirection Direction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the relative volume change
        /// </summary>
        public long RelativeChange
        {
            get { return _RelativeChange; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "A volume adjustment must be greater than zero");

                _RelativeChange = value;
            }
        }

        /// <summary>
        /// Gets or sets the peak volume
        /// </summary>
        public long Peak
        {
            get { return _Peak; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value", "A volume adjustment must be greater than zero");

                _Peak = value;
            }
        }
    }
}
