using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The encrytion frame is required when a frame is encrypted.
    /// </summary>
    public class Encryption : BaseFrame
    {
        private byte _Method;

        public override string Name
        {
            get { return "ENCR"; }
        }

        internal override string UniqueId
        {
            get
            {
                return Name + Owner + Id.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the owner identifier for this encryption method
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the encryption method identifier
        /// </summary>
        public byte Id
        {
            get{return _Method;}
            set
            {
                if (value < 0x80)
                    throw new ArgumentOutOfRangeException("value", "Methods less than 0x80 are reserved.");

                _Method = value;
            }
        }

        /// <summary>
        /// Gets or sets the encryption data
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }

		internal Encryption(FrameCollection frames)
			: base(frames)
		{ }

    }
}
