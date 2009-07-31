using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData
{
    /// <summary>
    /// Raises an ID3 related exception
    /// </summary>
    public class ID3Exception : Exception
    {
        public ID3Exception()
            : base()
        { }

        public ID3Exception(string message)
            : base(message)
        { }

        public ID3Exception(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
