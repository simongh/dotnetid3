using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MpegData.v23
{
	/// <summary>
	/// Represents the genre of the recoding
	/// </summary>
	public struct Genre
	{
		private string _Genre;
		private int _Legacy;
		private bool _Remix;
		private bool _Cover;

		/// <summary>
		/// Gets or sets the genre as text. Setting this will clear any legacy genre.
		/// </summary>
		public string Text
		{
			get { return _Genre; }
			set
			{
				_Genre = value;
				_Legacy = -1;
			}
		}

		/// <summary>
		/// Gets or sets the genre as a legacy code. Setting this will clear any text.
		/// </summary>
		public int LegacyGenre
		{
			get { return _Legacy; }
			set
			{
				if (value < -1 || value > 125)
					throw new ArgumentOutOfRangeException("Legacy genre code should be between 0 and 125.");

				_Legacy = value;
				_Genre = null;
			}
		}

		public bool Remix
		{
			get { return _Remix; }
			set { _Remix = value; }
		}

		public bool Cover
		{
			get { return _Cover; }
			set { _Cover = value; }
		}

		public Genre(int genre)
		{
			_Legacy = genre;
			_Genre = null;

			_Cover = false;
			_Remix = false;
		}

		public Genre(string genre)
		{
			Match m = Regex.Match(genre, @"^\((\d{1,3})\)");
			if (m.Success)
			{
				_Legacy = int.Parse(m.Groups[1].Value);
				_Genre = null;
			}
			else
			{
				_Legacy = -1;
				_Genre = genre;
			}

			_Cover = false;
			_Remix = false;

			if (Regex.Match(genre, "\\(RX\\)").Success)
				Remix = true;

			if (Regex.Match(genre, "\\(CR\\)").Success)
				Cover = true;
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();

			if (_Legacy > -1)
				result.AppendFormat("({0})", LegacyGenre);

			result.Append(Regex.Replace(Text, "\\(", "\\(\\("));
			if (Remix)
				result.Append("(RX)");

			if (Cover)
				result.Append("(CR");

			return result.ToString();
		}
	}
}
