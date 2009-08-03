using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData.v1
{
    public class Tag
    {
        private string _SongTitle;
        private string _Artist;
        private string _Album;
        private Int16 _Year;
        private string _Comment;

        private readonly Encoding _Encoder;

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

        public byte Genre
        {
            get;
            set;
        }

        public byte? Track
        {
            get;
            set;
        }

        public Tag()
        {
            _Encoder = Encoding.ASCII;
        }

        internal byte[] ToArray()
        {
            MemoryStream data = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(data, Encoding.ASCII);

            bw.Write(SongTitle);
            Padding(bw, 30);

            bw.Write(Artist);
            Padding(bw, 60);

            bw.Write(Album);
            Padding(bw, 90);

            bw.Write(Year.ToString("0000"));

            if (Track.HasValue && Comment != null && Comment.Length > 28)
                Comment = Comment.Remove(28);

            bw.Write(Comment);
            Padding(bw, 124);

            if (Track.HasValue)
            {
                bw.Write((byte)0);
                bw.Write(Track.Value);
            }

            bw.Write(Genre);

            bw.Flush();
            return data.ToArray();
        }

        private void Padding(BinaryWriter bw, int length)
        {
            while (bw.BaseStream.Length <= length)
            {
                bw.Write((byte)0);
            }
        }

        public static bool HasTag(Stream stream)
        {
            stream.Seek(-128, SeekOrigin.End);

            return stream.ReadByte() == 84 && stream.ReadByte() == 65 && stream.ReadByte() == 71;
        }

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

        private string ReadField(byte[] field)
        {
            List<byte> buffer = new List<byte>();
            foreach (byte item in field)
            {
                if (item == 0)
                    break;

                buffer.Add(item);
            }

            return _Encoder.GetString(buffer.ToArray());
        }

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
