using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
	public class CompressFrameEventArgs : EventArgs
	{
		public byte[] Data
		{
			get;
			set;
		}

		public bool Clear
		{
			get;
			set;
		}

		public CompressFrameEventArgs(byte[] data)
		{
			Data = data;
		}
	}
}
