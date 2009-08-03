using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
	public class EncryptFrameEventArgs : EventArgs
	{
		public byte[] Data
		{
			get;
			set;
		}

		public byte Method
		{
			get;
			private set;
		}

		public bool Clear
		{
			get;
			set;
		}

		public EncryptFrameEventArgs(byte[] data, byte method)
			: base()
		{
			Data = data;
			Method = method;
		}
		
	}
}
