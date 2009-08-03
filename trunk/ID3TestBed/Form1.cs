using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			ReadWrite();
        }

		private void RunTests()
		{
			StringBuilder sb = new StringBuilder();
			System.Collections.ObjectModel.ReadOnlyCollection<string> G = MpegData.v1.Genre.GetGenres();
			try
			{
				foreach (string item in Directory.GetFiles("C:\\Users\\Simon\\Desktop\\id3v1", "*.mp3"))
				{
					sb.AppendLine(item);
					try
					{
						MpegData.v1.Tag myTag = MpegData.v1.Tag.GetTag(File.Open(item, FileMode.Open));

						if (myTag != null)
						{
							sb.AppendFormat("Title  : \"{0}\"{1}", myTag.SongTitle, Environment.NewLine);
							sb.AppendFormat("Artist : \"{0}\"{1}", myTag.Artist, Environment.NewLine);
							sb.AppendFormat("Album  : \"{0}\"{1}", myTag.Album, Environment.NewLine);
							sb.AppendFormat("Year   : \"{0}\"{1}", myTag.Year, Environment.NewLine);
							sb.AppendFormat("Comment: \"{0}\"{1}", myTag.Comment, Environment.NewLine);
							if (myTag.Track.HasValue)
								sb.AppendFormat("Track  : {0}{1}", myTag.Track, Environment.NewLine);
							sb.AppendFormat("Genre  : {0} ({1})", myTag.Genre, myTag.Genre < G.Count ? G[myTag.Genre] : "?");
						}
					}
					catch (MpegData.ID3Exception)
					{
						sb.AppendLine("Error parsing file.");
					}

					sb.AppendLine();
					sb.AppendLine();
				}
			}
			catch (Exception ex)
			{
				sb.AppendLine(ex.Message);
			}
			textBox1.Text = sb.ToString();
		}

		private void ReadWrite()
		{
			FileStream file = File.Open(@"C:\Users\Simon\Desktop\id3v1\simon.mp3", FileMode.Open, FileAccess.ReadWrite);
			MpegData.v1.Tag myTag = MpegData.v1.Tag.GetTag(file);

			ShowTag(myTag);

			myTag.Artist = null;
			myTag.Album = null;
			myTag.Track = 15;
			myTag.Genre = 5;

			MpegData.v1.Tag.WriteTag(myTag, file);
			file.Close();

			file = File.Open(@"C:\Users\Simon\Desktop\id3v1\simon.mp3", FileMode.Open, FileAccess.ReadWrite);
			myTag = MpegData.v1.Tag.GetTag(file);

			ShowTag(myTag);
		}

		private void ShowTag(MpegData.v1.Tag tag)
		{
			System.Collections.ObjectModel.ReadOnlyCollection<string> G = MpegData.v1.Genre.GetGenres();
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Title  : \"{0}\"{1}", tag.SongTitle, Environment.NewLine);
			sb.AppendFormat("Artist : \"{0}\"{1}", tag.Artist, Environment.NewLine);
			sb.AppendFormat("Album  : \"{0}\"{1}", tag.Album, Environment.NewLine);
			sb.AppendFormat("Year   : \"{0}\"{1}", tag.Year, Environment.NewLine);
			sb.AppendFormat("Comment: \"{0}\"{1}", tag.Comment, Environment.NewLine);
			if (tag.Track.HasValue)
				sb.AppendFormat("Track  : {0}{1}", tag.Track, Environment.NewLine);
			sb.AppendFormat("Genre  : {0} ({1})", tag.Genre, tag.Genre < G.Count ? G[tag.Genre] : "?");

			textBox1.Text += sb.ToString();
		}
    }
}
