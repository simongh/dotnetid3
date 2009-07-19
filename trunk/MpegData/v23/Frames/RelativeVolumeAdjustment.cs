using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Defines the various volume adjustments
    /// </summary>
    public class RelativeVolumeAdjustment : BaseFrame
    {
        public override string Name
        {
            get { return "RVAD"; }
        }

        /// <summary>
        /// Gets or sets the bits used to store the adjustment. Leave as zero to have it calculated.
        /// </summary>
        internal byte FieldSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the front left speaker
        /// </summary>
        public VolumeAdjustment FrontLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the front right speaker
        /// </summary>
        public VolumeAdjustment FrontRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the rear left speaker
        /// </summary>
        public VolumeAdjustment RearLeft
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the rear right speaker
        /// </summary>
        public VolumeAdjustment RearRight
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the centre speaker
        /// </summary>
        public VolumeAdjustment Centre
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets adjustments for the bass/sub speaker
        /// </summary>
        public VolumeAdjustment Bass
        {
            get;
            set;
        }
    }
}
