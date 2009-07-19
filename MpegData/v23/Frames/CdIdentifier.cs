using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Allows the CD related to this file to be located in services like CDDB
    /// </summary>
    public class CdIdentifier : BaseFrame
    {
        public override string Name
        {
            get { return "MCDI"; }
        }

        /// <summary>
        /// Gets or sets the binary dump of the table of contents
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }
    }
}
