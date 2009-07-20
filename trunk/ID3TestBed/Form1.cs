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
            catch(Exception ex)
            {
                sb.AppendLine(ex.Message);
            }
                textBox1.Text = sb.ToString();
        }
    }
}
