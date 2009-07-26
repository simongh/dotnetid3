using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The initial key in the format (A|B|C|D|E|F|G)(b|#|m|o)
    /// </summary>
    public class InitialKey : SingleValueTextFrame
    {
        public override string Name
        {
            get { return "TKEY"; }
        }

        public override string Value
        {
            get { return base.Value; }
            set
            {
                if (value != null)
                    if (!System.Text.RegularExpressions.Regex.IsMatch(value, "^[abcdefgABCDEFG][b#om]{,2}$"))
                        throw new ArgumentException("The initial key was not in a valid format.");

                base.Value = value;
            }
        }
    }
}
