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

		internal Album(FrameCollection frames)
			: base(frames)
		{ }
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

		internal EncodedBy(FrameCollection frames)
			: base(frames)
		{ }
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

		internal ContentGroup(FrameCollection frames)
			: base(frames)
		{ }
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

		internal Title(FrameCollection frames)
			: base(frames)
		{ }
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

		internal SubTitle(FrameCollection frames)
			: base(frames)
		{ }
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

		internal OriginalTitle(FrameCollection frames)
			: base(frames)
		{ }
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

		internal OriginalFilename(FrameCollection frames)
			: base(frames)
		{ }
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

		internal FileOwner(FrameCollection frames)
			: base(frames)
		{ }
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

		internal Band(FrameCollection frames)
			: base(frames)
		{ }
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

		internal Conductor(FrameCollection frames)
			: base(frames)
		{ }
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

		internal RemixedBy(FrameCollection frames)
			: base(frames)
		{ }
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

		internal Publisher(FrameCollection frames)
			: base(frames)
		{ }
    }

    /// <summary>
    /// The recording dates
    /// </summary>
    public class RecordingDates : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TRDA"; }
        }

		internal RecordingDates(FrameCollection frames)
			: base(frames)
		{ }
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

		internal InternetRadioStationName(FrameCollection frames)
			: base(frames)
		{ }
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

		internal InternetRadioStationOwner(FrameCollection frames)
			: base(frames)
		{ }
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

		internal ISRC(FrameCollection frames)
			: base(frames)
		{ }
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

		internal EncoderSettings(FrameCollection frames)
			: base(frames)
		{ }
    }
}
