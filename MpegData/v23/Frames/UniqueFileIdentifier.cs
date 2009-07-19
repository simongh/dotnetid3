using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Allows the file to be uniquely identified in a database
    /// </summary>
    public class UniqueFileIdentifier : BaseFrame
    {
        private byte[] _Identifer;

        public override string Name
        {
            get { return "UFID"; }
        }

        internal override string UniqueId
        {
            get { return Name + Owner; }
        }

        /// <summary>
        /// Gets or sets the organisation responsible for the database
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the unique identifier. The identifier can be a maximum of 64 bytes long.
        /// </summary>
        public byte[] Identifier
        {
            get { return _Identifer; }
            set
            {
                if (value.Length >= 64)
                    throw new ArgumentException("The identifier cannot be longer than 64 bytes long.");

                _Identifer = value;
            }
        }
    }
}
