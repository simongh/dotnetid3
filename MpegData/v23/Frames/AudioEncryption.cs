using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Indicates data about the audio encryption scheme
    /// </summary>
    public class AudioEncryption : BaseFrame
    {
        public override string Name
        {
            get { return "AENC"; }
        }

        internal override string UniqueId
        {
            get { return Name + Owner; }
        }

        /// <summary>
        /// Gets or sets the owner to contact about the encryption method
        /// </summary>
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the frame where an unencrypted preview starts
        /// </summary>
        public int PreviewStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the frame where an unencrypted preview ends
        /// </summary>
        public int PreviewEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets data needed by the encryption scheme
        /// </summary>
        public System.IO.Stream Data
        {
            get;
            set;
        }
    }
}
