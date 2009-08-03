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
        internal FrameCollection(Tag parent)
            : base(parent)
        { }

        internal override void ImportData(BinaryReader reader)
        {
            long endPos = reader.BaseStream.Position + ParentTag.Size;
            if (((Tag)ParentTag).ExtendedHeader != null)
                endPos -= ParentTag.ExtendedHeader.Padding;

            BaseFrame frame = null;
			byte[] buffer;
            while (reader.BaseStream.Position < endPos)
            {
				frame = GetFrameFromId(Encoding.ASCII.GetString(ParentTag.IsUnsynchronised ? Util.Unsync(reader, 4) : reader.ReadBytes(4)));
				
				frame.Size = Util.ConvertToInt64(ParentTag.IsUnsynchronised ? Util.Unsync(reader, 4) : reader.ReadBytes(4));
				frame.ReadFlags(ParentTag.IsUnsynchronised ? Util.Unsync(reader, 2) : reader.ReadBytes(2));

				if (frame.IsCompressed)
				{
					frame.DecompressedSize = Util.ConvertToInt64(ParentTag.IsUnsynchronised ? Util.Unsync(reader, 4) : reader.ReadBytes(4));
					frame.Size -= 4;
				}
				if (frame.IsEncrypted)
				{
					frame.EncryptionMethod = ParentTag.IsUnsynchronised ? Util.Unsync(reader) : reader.ReadByte();
					frame.Size--;
				}
				if (frame.IsInGroup)
				{
					frame.GroupId = ParentTag.IsUnsynchronised ? Util.Unsync(reader) : reader.ReadByte();
					frame.Size--;
				}

				buffer = ParentTag.IsUnsynchronised ? Util.Unsync(reader, (int)frame.Size) : reader.ReadBytes((int)frame.Size);

				if (frame.IsCompressed || frame.IsEncrypted)
				{
					Frames.Unknown newframe = new Frames.Unknown(this, frame.Name);
					Copy(frame, newframe);

					newframe.Data = buffer;
				}
				else
					frame.ParseBody(buffer);

                this.Add(frame);
            }
        }

		public void Copy(BaseFrame frameFrom, BaseFrame frameTo)
		{
			frameTo.DecompressedSize = frameFrom.DecompressedSize;
			frameTo.EncryptionMethod = frameFrom.EncryptionMethod;
			frameTo.GroupId = frameFrom.GroupId;
			frameTo.IsCompressed = frameFrom.IsCompressed;
			frameTo.IsEncrypted = frameFrom.IsEncrypted;
			frameTo.IsInGroup = frameFrom.IsInGroup;
			frameTo.IsReadOnly = frameFrom.IsReadOnly;
			frameTo.PreserveOnFileChange = frameFrom.PreserveOnFileChange;
			frameTo.PreserveOnTagChange = frameFrom.PreserveOnTagChange;
		}

        /// <summary>
        /// Create a frame from a frame ID string
        /// </summary>
        /// <param name="frameId">4 character frame ID</param>
        /// <returns>a valid frame</returns>
        public BaseFrame GetFrameFromId(string frameId)
        {
            switch (frameId)
            {
                case "AENC":
                    return new Frames.AudioEncryption(this);
                case "APIC":
					return new Frames.AttachedImage(this);
                case "COMM":
					return new Frames.Comments(this);
                case "COMR":
                    throw new NotImplementedException();
                case "ENCR":
					return new Frames.Encryption(this);
                case "EQUA":
					return new Frames.Equalisation(this);
                case "ETCO":
					return new Frames.EventTimingCodes(this);
                case "GEOB":
					return new Frames.AttachedFile(this);
                case "GRID":
					return new Frames.Group(this);
                case "IPLS":
					return new Frames.InvolvedPeopleList(this);
                case "LINK":
					return new Frames.Link(this);
                case "MCDI":
					return new Frames.CdIdentifier(this);
                case "MLLT":
                    throw new NotImplementedException();
                case "OWNE":
					return new Frames.Ownership(this);
                case "PRIV":
					return new Frames.PrivateData(this);
                case "PCNT":
					return new Frames.PlayCounter(this);
                case "POPM":
					return new Frames.Popularimeter(this);
                case "POSS":
					return new Frames.PositionSync(this);
                case "RBUF":
                    throw new NotImplementedException();
                case "RVAD":
					return new Frames.RelativeVolumeAdjustment(this);
                case "RVRB":
					return new Frames.Reverb(this);
                case "SYLT":
					return new Frames.SyncedLyrics(this);
                case "SYTC":
					return new Frames.SyncedTempoCodes(this);
                case "TALB":
					return new Frames.Album(this);
                case "TBPM":
					return new Frames.Bpm(this);
                case "TCOM":
					return new Frames.Composers(this);
                case "TCON":
					return new Frames.ContentType(this);
                case "TCOP":
					return new Frames.Copyright(this);
                case "TDAT":
                    throw new NotImplementedException();
                case "TDLY":
					return new Frames.PlaylistDelay(this);
                case "TENC":
					return new Frames.EncodedBy(this);
                case "TEXT":
					return new Frames.Lyricists(this);
                case "TFLT":
                    throw new NotImplementedException();
                case "TIME":
                    throw new NotImplementedException();
                case "TIT1":
					return new Frames.ContentGroup(this);
                case "TIT2":
					return new Frames.Title(this);
                case "TIT3":
					return new Frames.SubTitle(this);
                case "TKEY":
					return new Frames.InitialKey(this);
                case "TLAN":
					return new Frames.Languages(this);
                case "TLEN":
					return new Frames.FileLength(this);
                case "TMED":
					throw new NotImplementedException();
                case "TOAL":
					return new Frames.OriginalTitle(this);
                case "TOFN":
					return new Frames.OriginalFilename(this);
                case "TOLY":
					return new Frames.OriginalLyricists(this);
                case "TOPE":
					return new Frames.OriginalArtists(this);
                case "TORY":
					return new Frames.OriginalReleaseYear(this);
                case "TOWN":
					return new Frames.FileOwner(this);
                case "TPE1":
					return new Frames.LeadArtists(this);
                case "TPE2":
					return new Frames.Band(this);
                case "TPE3":
					return new Frames.Conductor(this);
                case "TPE4":
					return new Frames.RemixedBy(this);
                case "TPOS":
					return new Frames.Set(this);
                case "TPUB":
					return new Frames.Publisher(this);
                case "TRCK":
					return new Frames.Track(this);
                case "TRDA":
					return new Frames.RecordingDates(this);
                case "TRSN":
					return new Frames.InternetRadioStationName(this);
                case "TRSO":
					return new Frames.InternetRadioStationOwner(this);
                case "TSIZ":
					return new Frames.FileSize(this);
                case "TSRC":
					return new Frames.ISRC(this);
                case "TSSE":
					return new Frames.EncoderSettings(this);
                case "TYER":
					return new Frames.ReleaseYear(this);
                case "TXXX":
					return new Frames.UserText(this);
                case "UFID":
					return new Frames.UniqueFileIdentifier(this);
                case "USER":
					return new Frames.TermsOfUse(this);
                case "USLT":
					return new Frames.UnsyncedLyrics(this);
                case "WCOM":
					return new Frames.UrlLink(this, UrlLinkType.Commercial);
                case "WCOP":
					return new Frames.UrlLink(this, UrlLinkType.Copyright);
                case "WOAF":
					return new Frames.UrlLink(this, UrlLinkType.AudioFile);
                case "WOAR":
					return new Frames.UrlLink(this, UrlLinkType.Artist);
                case "WOAS":
					return new Frames.UrlLink(this, UrlLinkType.AudioSource);
                case "WORS":
					return new Frames.UrlLink(this, UrlLinkType.InternetRadioHome);
                case "WPAY":
					return new Frames.UrlLink(this, UrlLinkType.Payment);
                case "WPUB":
					return new Frames.UrlLink(this, UrlLinkType.Publisher);
                case "WXXX":
					return new Frames.UserUrlLink(this);
                default:
					return new Frames.Unknown(this, frameId);
            }
        }

		internal override void ToBinary(BinaryWriter writer)
		{
			foreach (BaseFrame item in this)
			{
				item.ToBinary(writer);
			}
		}
	}
}
