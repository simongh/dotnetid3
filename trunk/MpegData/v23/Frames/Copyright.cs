using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The copyright of the original recording
    /// </summary>
    public class Copyright : BaseTextFrame
    {
        private int _Year;

        public override string Name
        {
            get { return "TCOP"; }
        }

        /// <summary>
        /// Gets or sets the 4 digit year of the copyright
        /// </summary>
        public int Year
        {
            get { return _Year; }
            set
            {
                if (value > 9999)
                    throw new ArgumentOutOfRangeException("The year should be a vlaid 4 digit year.");

                _Year = value;
            }
        }

        /// <summary>
        /// Gets or sets the optional copyright message
        /// </summary>
        public string Message
        {
            get;
            set;
        }

		internal Copyright(FrameCollection frames)
			: base(frames)
		{ }

		internal override void ParseBody(byte[] data)
		{
			throw new NotImplementedException();
		}

		protected override byte[] BodyToArray()
		{
			throw new NotImplementedException();
		}
	}
}
