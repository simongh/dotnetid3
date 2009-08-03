using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
	public class CRCEventArgs : EventArgs
	{
		public byte[] Data
		{
			get;
			private set;
		}

		public byte[] CRC
		{
			get;
			set;
		}

		public CRCEventArgs(byte[] data)
			: base()
		{
			Data = data;
		}
				
	}
}
