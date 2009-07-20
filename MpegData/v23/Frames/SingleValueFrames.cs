using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The Album/Movie/Show title
    /// </summary>
    public class Album : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TALB"; }
        }
    }

    /// <summary>
    /// The person/organisation who encoded the file
    /// </summary>
    public class EncodedBy : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TENC"; }
        }
    }

    /// <summary>
    /// Used if the audio belongs to a larger category of music/sounds
    /// </summary>
    public class ContentGroup : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TIT1"; }
        }
    }

    /// <summary>
    /// The title/Songname/Content description
    /// </summary>
    public class Title : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TIT2"; }
        }
    }

    /// <summary>
    /// The Subtitle/description refinement
    /// </summary>
    public class SubTitle : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TIT3"; }
        }
    }

    /// <summary>
    /// The title used by the original recoding
    /// </summary>
    public class OriginalTitle : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TOAL"; }
        }
    }

    /// <summary>
    /// The preferred filename for the file
    /// </summary>
    public class OriginalFilename : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TOFN"; }
        }
    }

    /// <summary>
    /// The file owner/licensee
    /// </summary>
    public class FileOwner : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TOWN"; }
        }
    }

    /// <summary>
    /// The band/orchestra/accompaniment
    /// </summary>
    public class Band : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TPE2"; }
        }
    }

    /// <summary>
    /// The conductor
    /// </summary>
    public class Conductor : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TPE3"; }
        }
    }

    /// <summary>
    /// Any interpreted by, remixed or other wise modified by
    /// </summary>
    public class RemixedBy : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TPE4"; }
        }
    }

    /// <summary>
    /// The publisher/label
    /// </summary>
    public class Publisher : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TPUB"; }
        }
    }

    /// <summary>
    /// The recording dates
    /// </summary>
    public class RecordingDate : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TRDA"; }
        }
    }
    
    /// <summary>
    /// the internet radio station name
    /// </summary>
    public class InternetRadioStationName : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TRSN"; }
        }
    }

    /// <summary>
    /// the internet radio station owner
    /// </summary>
    public class InternetRadioStationOwner : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TRSO"; }
        }
    }

    /// <summary>
    /// The ISRC code
    /// </summary>
    public class ISRC : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TSRC"; }
        }

        public override string Value
        {
            get { return base.Value; }
            set
            {
                if (value != null && value.Length > 12)
                    throw new ArgumentException("ISRC should be 12 charcters.");
                base.Value = value;
            }
        }
    }

    /// <summary>
    ///Hardware/software encoder settings
    /// </summary>
    public class EncoderSettings : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TSSE"; }
        }
    }
}
