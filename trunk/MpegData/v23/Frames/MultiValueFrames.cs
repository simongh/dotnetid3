using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The composers
    /// </summary>
    public class Composers : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TCOM"; }
        }
    }

    /// <summary>
    /// The lyricist/text writer
    /// </summary>
    public class Lyricists : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TEXT"; }
        }
    }

    /// <summary>
    /// The languages of the text. The order should follow the usage.
    /// </summary>
    public class Languages : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TLAN"; }
        }
    }

    /// <summary>
    /// The lyricist/text writer of the orginal recording
    /// </summary>
    public class OriginalLyricists : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TOLY"; }
        }
    }

    /// <summary>
    /// The performer of the original recording
    /// </summary>
    public class OriginalArtists : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TOPE"; }
        }
    }

    /// <summary>
    /// The lead performer/artist/etc
    /// </summary>
    public class LeadArtists : MultiValueTextFrame
    {
        public override string Name
        {
            get { return "TPE1"; }
        }
    }

}
