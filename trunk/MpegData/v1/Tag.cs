using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v1
{
	/// <summary>
	/// A v1.0 or v1.1 tag
	/// </summary>
    public class Tag
    {
        private string _SongTitle;
        private string _Artist;
        private string _Album;
        private Int16 _Year;
        private string _Comment;
        private readonly Encoding _Encoder;

		/// <summary>
		/// Gets or sets the title of this tag.
		/// </summary>
        public string SongTitle
        {
            get { return _SongTitle; }
            set
            {
                if (value != null && value.Length > 30)
                    throw new ArgumentException("The maximum field length is 30");
                _SongTitle = value;
            }
        }
        
		/// <summary>
		/// Gets or sets the artist for this tag.
		/// </summary>
        public string Artist
        {
            get { return _Artist; }
            set
            {
                if (value != null && value.Length > 30)
                    throw new ArgumentException("The maximum field length is 30");
                _Artist = value;
            }
        }
        
		/// <summary>
		/// Gets or sets the album name for this tag.
		/// </summary>
        public string Album
        {
            get { return _Album; }
            set
            {
                if (value != null && value.Length > 30)
                    throw new ArgumentException("The maximum field length is 30");
                _Album = value;
            }
        }
        
		/// <summary>
		/// Gets or sets a comment for the tag. If a track is defined, the comment length is reduced by 2.
		/// </summary>
        public string Comment
        {
            get { return _Comment; }
            set
            {
                if (value != null && value.Length > 30)
                    throw new ArgumentException("The maximum field length is 30");

                _Comment = value;
            }
        }

		/// <summary>
		/// Gets or sets the year of this tag.
		/// </summary>
        public Int16 Year
        {
            get { return _Year; }
            set
            {
                if (value < 0 && value > 9999)
                    throw new ArgumentOutOfRangeException("The year must be in the range 0 to 9999");
                _Year = value;
            }
        }

		/// <summary>
		/// Gets or sets the genre
		/// </summary>
        public byte Genre
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets the track number. Set this to null for a v1.0 compliant tag.
		/// </summary>
        public byte? Track
        {
            get;
            set;
        }

		/// <summary>
		/// Create a new v1.0/v1.1 tag
		/// </summary>
        public Tag()
        {
            _Encoder = Encoding.ASCII;
        }

		/// <summary>
		/// Converts the tag body to a binary array, less the header
		/// </summary>
		/// <returns>binary array containing the tag fields</returns>
        internal byte[] ToArray()
        {
			byte[] result = new byte[125];

			if (SongTitle !=null) _Encoder.GetBytes(SongTitle, 0, SongTitle.Length, result, 0);
			if (Album !=null) _Encoder.GetBytes(Album, 0, Album.Length, result, 30);
			if (Artist !=null)_Encoder.GetBytes(Artist, 0, Artist.Length, result, 60);
			_Encoder.GetBytes(Year.ToString("0000"), 0, 4, result, 90);

            if (Track.HasValue && Comment != null && Comment.Length > 28)
                Comment = Comment.Remove(28);

			if (Comment != null) _Encoder.GetBytes(Comment, 0, Comment.Length, result, 94);

            if (Track.HasValue)
            {
				result[123] = Track.Value;
            }
			result[124] = Genre;

			return result;
        }

		/// <summary>
		/// Determine if a v1 tag is present in the stream
		/// </summary>
		/// <param name="stream">Stream to search for a v1 tag. The stream should allow seeking.</param>
		/// <returns>true if a v1 tag is found</returns>
        public static bool HasTag(Stream stream)
        {
            stream.Seek(-128, SeekOrigin.End);

            return stream.ReadByte() == 84 && stream.ReadByte() == 65 && stream.ReadByte() == 71;
        }

		/// <summary>
		/// Gets a v1 tag from a stream
		/// </summary>
		/// <param name="stream">a stream to search for a tag. The stream should allow seeking</param>
		/// <returns>the v1 tag from the stream or null is one is not present</returns>
        public static Tag GetTag(Stream stream)
        {
            if (!HasTag(stream))
                return null;

            BinaryReader br = new BinaryReader(stream);

            Tag result = new Tag();

            try
            {
                result.SongTitle = result.ReadField(br.ReadBytes(30));
                result.Artist = result.ReadField(br.ReadBytes(30));
                result.Album = result.ReadField(br.ReadBytes(30));
                result.Year = short.Parse(result._Encoder.GetString(br.ReadBytes(4)));
                result.Comment = result.ReadField(br.ReadBytes(28));

                byte[] buffer = br.ReadBytes(2);
                if (buffer[0] == 0 && buffer[1] > 0)
                    result.Track = buffer[1];
                else
                    result.Comment += result.ReadField(buffer);

                result.Genre = br.ReadByte();
            }
            catch
            {
                throw new ID3Exception("The tag appears to be corrupted and cannot be parsed.");
            }
            return result;
        }

		/// <summary>
		/// Reads a sequence of non-null bytes from an array and returns them as a string
		/// </summary>
		/// <param name="field">byte array to read from</param>
		/// <returns>string of characters from the array or null if no characters are present</returns>
        private string ReadField(byte[] field)
        {
            List<byte> buffer = new List<byte>();
            foreach (byte item in field)
            {
                if (item == 0)
                    break;

                buffer.Add(item);
            }

			if (buffer.Count == 0)
				return null;

            return _Encoder.GetString(buffer.ToArray());
        }

		/// <summary>
		/// Writes the tag to the stream. An existing tag is overwritten.
		/// </summary>
		/// <param name="tag">Tag to write to the stream</param>
		/// <param name="stream">Stream to write to. The stream should allow seeking</param>
        public static void WriteTag(Tag tag, Stream stream)
        {
            if (!HasTag(stream))
            {
                stream.Seek(0, SeekOrigin.End);
                stream.WriteByte(84);
                stream.WriteByte(65);
                stream.WriteByte(71);
            }

            stream.Write(tag.ToArray(), 0, 125);
        }

    }
}
