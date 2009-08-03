using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    /// <summary>
    /// Base ID3 tag
    /// </summary>
    public abstract class BaseTag
    {

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

        /// <summary>
        /// Populate the tag with data
        /// </summary>
        /// <param name="reader">The stream contianing the data for this tag</param>
        internal abstract void ImportData(BinaryReader reader);

		internal abstract void ExportData(BinaryWriter writer);

    }

}
