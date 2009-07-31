using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v23
{
    /// <summary>
    /// Frame collection for v2.3.0 frames
    /// </summary>
    public class FrameCollection : BaseFrameCollection
    {
        /// <summary>
        /// Gets the tag this collection belongs to
        /// </summary>
        public new Tag ParentTag
        {
            get;
            private set;
        }

        /// <summary>
        /// Create a frame collection
        /// </summary>
        /// <param name="parent">The tag this collection belongs to</param>
        public FrameCollection(Tag parent)
            : base(parent)
        { }

        internal override void ImportData(BinaryReader reader)
        {
            long endPos = reader.BaseStream.Position + ParentTag.Size;
            if (((Tag)ParentTag).ExtendedHeader != null)
                endPos -= ParentTag.ExtendedHeader.Padding;

            BaseFrame frame = null;
            while (reader.BaseStream.Position < endPos)
            {
                frame = FrameCollection.GetFrameFromId(Encoding.ASCII.GetString(ParentTag.IsUnsynchronised ? Util.Unsync(reader, 4) : reader.ReadBytes(4)));
                frame.ImportData(reader, ParentTag.IsUnsynchronised);
                this.Add(frame);
            }
        }

        /// <summary>
        /// Create a frame from a frame ID string
        /// </summary>
        /// <param name="frameId">4 character frame ID</param>
        /// <returns>a valid frame</returns>
        public static BaseFrame GetFrameFromId(string frameId)
        {
            switch (frameId)
            {
                case "AENC":
                    return new Frames.AudioEncryption();
                case "APIC":
                    return new Frames.AttachedImage();
                case "COMM":
                    return new Frames.Comments();
                case "COMR":
                    throw new NotImplementedException();
                case "ENCR":
                    return new Frames.Encryption();
                case "EQUA":
                    return new Frames.Equalisation();
                case "ETCO":
                    return new Frames.EventTimingCodes();
                case "GEOB":
                    return new Frames.AttachedFile();
                case "GRID":
                    return new Frames.Group();
                case "IPLS":
                    return new Frames.InvolvedPeopleList();
                case "LINK":
                    return new Frames.Link();
                case "MCDI":
                    return new Frames.CdIdentifier();
                case "MLLT":
                    throw new NotImplementedException();
                case "OWNE":
                    return new Frames.Ownership();
                case "PRIV":
                    return new Frames.PrivateData();
                case "PCNT":
                    return new Frames.PlayCounter();
                case "POPM":
                    return new Frames.Popularimeter();
                case "POSS":
                    return new Frames.PositionSync();
                case "RBUF":
                    throw new NotImplementedException();
                case "RVAD":
                    return new Frames.RelativeVolumeAdjustment();
                case "RVRB":
                    return new Frames.Reverb();
                case "SYLT":
                    return new Frames.SyncedLyrics();
                case "SYTC":
                    return new Frames.SyncedTempoCodes();
                case "TALB":
                    return new Frames.Album();
                case "TBPM":
                    return new Frames.Bpm();
                case "TCOM":
                    return new Frames.Composers();
                case "TCON":
                    return new Frames.ContentType();
                case "TCOP":
                    return new Frames.Copyright();
                case "TDAT":
                    throw new NotImplementedException();
                case "TDLY":
                    return new Frames.PlaylistDelay();
                case "TENC":
                    return new Frames.EncodedBy();
                case "TEXT":
                    return new Frames.Lyricists();
                case "TFLT":
                    throw new NotImplementedException();
                case "TIME":
                    throw new NotImplementedException();
                case "TIT1":
                    return new Frames.ContentGroup();
                case "TIT2":
                    return new Frames.Title();
                case "TIT3":
                    return new Frames.SubTitle();
                case "TKEY":
                    return new Frames.InitialKey();
                case "TLAN":
                    return new Frames.Languages();
                case "TLEN":
                    return new Frames.FileLength();
                case "TMED":
                    throw new NotImplementedException();
                case "TOAL":
                    return new Frames.OriginalTitle();
                case "TOFN":
                    return new Frames.OriginalFilename();
                case "TOLY":
                    return new Frames.OriginalLyricists();
                case "TOPE":
                    return new Frames.OriginalArtists();
                case "TORY":
                    return new Frames.OriginalReleaseYear();
                case "TOWN":
                    return new Frames.FileOwner();
                case "TPE1":
                    return new Frames.LeadArtists();
                case "TPE2":
                    return new Frames.Band();
                case "TPE3":
                    return new Frames.Conductor();
                case "TPE4":
                    return new Frames.RemixedBy();
                case "TPOS":
                    return new Frames.Set();
                case "TPUB":
                    return new Frames.Publisher();
                case "TRCK":
                    return new Frames.Track();
                case "TRDA":
                    return new Frames.RecordingDates();
                case "TRSN":
                    return new Frames.InternetRadioStationName();
                case "TRSO":
                    return new Frames.InternetRadioStationOwner();
                case "TSIZ":
                    return new Frames.FileSize();
                case "TSRC":
                    return new Frames.ISRC();
                case "TSSE":
                    return new Frames.EncoderSettings();
                case "TYER":
                    return new Frames.ReleaseYear();
                case "TXXX":
                    return new Frames.UserText();
                case "UFID":
                    return new Frames.UniqueFileIdentifier();
                case "USER":
                    return new Frames.TermsOfUse();
                case "USLT":
                    return new Frames.UnsyncedLyrics();
                case "WCOM":
                    return new Frames.UrlLink(UrlLinkType.Commercial);
                case "WCOP":
                    return new Frames.UrlLink(UrlLinkType.Copyright);
                case "WOAF":
                    return new Frames.UrlLink(UrlLinkType.AudioFile);
                case "WOAR":
                    return new Frames.UrlLink(UrlLinkType.Artist);
                case "WOAS":
                    return new Frames.UrlLink(UrlLinkType.AudioSource);
                case "WORS":
                    return new Frames.UrlLink(UrlLinkType.InternetRadioHome);
                case "WPAY":
                    return new Frames.UrlLink(UrlLinkType.Payment);
                case "WPUB":
                    return new Frames.UrlLink(UrlLinkType.Publisher);
                case "WXXX":
                    return new Frames.UserUrlLink();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
