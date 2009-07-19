using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Specifies how good a file is
    /// </summary>
    public class Popularimeter : BaseFrame
    {
        public override string Name
        {
            get { return "POPM"; }
        }

        internal override string UniqueId
        {
            get
            {
                return Name + Email;
            }
        }

        /// <summary>
        /// Gets or sets the email address of the user
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the rating. 1 is worst, 255 is best. 0 is unknown
        /// </summary>
        public byte Rating
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the play count
        /// </summary>
        public long Counter
        {
            get;
            set;
        }
    }
}
