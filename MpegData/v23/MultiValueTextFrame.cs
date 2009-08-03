using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// Store multiple text strings
    /// </summary>
    public abstract class MultiValueTextFrame : BaseFrame
    {
        /// <summary>
        /// Gets or sets the list of values
        /// </summary>
        public List<string> Values
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value. If the string contains multiple entries seperated by "/", it is split apart
        /// </summary>
        public string Value
        {
            get { return string.Join("/", Values.ToArray()); }
            set
            {
                if (value != null && value.Contains("/"))
                {
                    string[] ar = value.Split('/');
                    Values.AddRange(ar);
                }
                else
                {
                    Values.Add(value);
                }
            }
        }

		internal MultiValueTextFrame(FrameCollection frames)
			: base(frames)
		{ }
    }
}
