using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
	public enum TagVersion
	{
		v10 = 10,
		v11 = 11,
		v22 = 22,
		v23 = 23,
		v24 = 24
	}

    /// <summary>
    /// Base ID3 tag
    /// </summary>
    public abstract class BaseTag
    {

		public abstract TagVersion Version
		{
			get;
		}

        /// <summary>
        /// Gets or sets the size of the tag
        /// </summary>
        internal long Size
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the collection of frames in the tag
        /// </summary>
        public BaseFrameCollection Frames
        {
            get;
            protected set;
        }

		public List<BaseFrame> UnknownFrames
		{
			get;
			internal set;
		}

        /// <summary>
        /// Populate the tag with data
        /// </summary>
        /// <param name="reader">The stream contianing the data for this tag</param>
        internal abstract void Parse(BinaryReader reader);

		internal abstract void ToArray(BinaryWriter writer);

    }

}
