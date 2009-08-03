using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData
{
    /// <summary>
    /// Base ID3 frame
    /// </summary>
	public abstract class BaseFrame
	{
		/// <summary>
		/// Gets the frame name string
		/// </summary>
		public abstract string Name
		{
			get;
		}

		internal long Size
		{
			get;
			set;
		}

		public BaseFrameCollection Frames
		{
			get;
			internal set;
		}

		public BaseFrame()
		{ }

	}
}
