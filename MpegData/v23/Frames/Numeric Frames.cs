using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The delay between playlist items in milliseconds
    /// </summary>
    public class PlaylistDelay : NumericFrame
    {
        public override string Name
        {
            get { return "TDLY"; }
        }
    }

    /// <summary>
    /// Length of the audio file in milliseconds
    /// </summary>
    public class FileLength : NumericFrame
    {
        public override string Name
        {
            get { return "TLEN"; }
        }
    }

    /// <summary>
    /// BPM of the audio
    /// </summary>
    public class Bpm : NumericFrame
    {
        public override string Name
        {
            get { return "TBPM"; }
        }
    }

    /// <summary>
    /// Size of the audio file in bytes
    /// </summary>
    public class FileSize : NumericFrame
    {
        public override string Name
        {
            get { return "TSIZ"; }
        }
    }

    /// <summary>
    /// The release year (0-9999)
    /// </summary>
    public class ReleaseYear : NumericFrame
    {
        public override string Name
        {
            get { return "TYER"; }
        }

        public override int Value
        {
            get { return base.Value; }
            set
            {
                if (value < 0 || value > 9999)
                    throw new ArgumentOutOfRangeException("The value should be a valid year");

                base.Value = value;
            }
        }
    }

    /// <summary>
    /// The release year of the original recording
    /// </summary>
    public class OriginalReleaseYear : ReleaseYear
    {
        public override string Name
        {
            get { return "TORY"; }
        }
    }

    /// <summary>
    /// The track number/position in set
    /// </summary>
    public class Track : NumericFrame
    {
        public override string Name
        {
            get { return "TRCK"; }
        }

        /// <summary>
        /// Gets or sets the optional total track count
        /// </summary>
        public int Total
        {
            get;
            set;
        }
    }

}
