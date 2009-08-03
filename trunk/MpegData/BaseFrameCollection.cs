using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MpegData
{
    /// <summary>
    /// Base collection of ID3 frames
    /// </summary>
    public abstract class BaseFrameCollection : System.Collections.ObjectModel.Collection<BaseFrame>
    {
        /// <summary>
        /// Gets the tag that this collection belongs to
        /// </summary>
        public BaseTag ParentTag
        {
            get;
            protected set;
        }

        /// <summary>
        /// Creates the frame collection and sets the collection parent
        /// </summary>
        /// <param name="parent">The tag this collection belongs to</param>
        public BaseFrameCollection(BaseTag parent)
        {
            ParentTag = parent;
        }

        /// <summary>
        /// Parse the tag data for frames and fill the collection
        /// </summary>
        /// <param name="reader">Binary reader on the stream containing the data for the frames</param>
        internal abstract void ImportData(BinaryReader reader);

		internal abstract void ToBinary(BinaryWriter writer);

		protected override void InsertItem(int index, BaseFrame item)
		{
			base.InsertItem(index, item);

			item.Frames = this;
		}

		protected override void SetItem(int index, BaseFrame item)
		{
			base.SetItem(index, item);
			item.Frames = this;
		}

    }
}
