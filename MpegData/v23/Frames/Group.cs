using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// The group frame specifies extra data for a group of frames identified by the ID
    /// </summary>
    public class Group : BaseFrame
    {
        private byte _Id;

        public override string Name
        {
            get { return "GRID"; }
        }

        internal override string UniqueId
        {
            get { return Name; }
        }

        /// <summary>
        /// Gets or sets the owner ID for the group of frames related to this group
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the unique identifier for this group
        /// </summary>
        public byte Id
        {
            get { return _Id; }
            set
            {
                if (value < 0x80)
                    throw new ArgumentOutOfRangeException("value", "Id values below 0x80 are reserved.");

                _Id = value;
            }
        }

        /// <summary>
        /// Gets or sets the group dependant data
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }
    }
}
