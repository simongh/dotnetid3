using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
	public class Unknown : BaseFrame
	{
		private string _Name;

		public override string Name
		{
			get { return _Name; }
		}

		internal override string UniqueId
		{
			get { return null; }
		}

		public byte[] Data
		{
			get;
			set;
		}

		public Unknown(FrameCollection frames, string name)
			: base(frames)
		{
			_Name = name;
		}

		public BaseFrame DecompressFrame()
		{
			if (!this.IsCompressed)
				throw new ID3Exception("This frame is not compressed.");

			throw new NotImplementedException();
		}

		public BaseFrame DecryptFrame()
		{
			if (!this.IsEncrypted)
				throw new ID3Exception("This frame is not encrypted.");

			throw new NotImplementedException();
		}
	}
}
