using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    public class TermsOfUse : LanguageFrame
    {
        public override string Name
        {
            get { return "USER"; }
        }

        public string Value
        {
            get;
            set;
        }
    }
}
