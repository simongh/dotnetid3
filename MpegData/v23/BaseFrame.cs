using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23
{
    public abstract class BaseFrame
    {
        /// <summary>
        /// Gets the frame name string
        /// </summary>
        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Gets a unique name for this frame
        /// </summary>
        internal virtual string UniqueId
        {
            get { return Name; }
        }

        /// <summary>
        /// Gets or sets whether this frame is encrypted
        /// </summary>
        public bool IsEncrypted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the frame will be compressed
        /// </summary>
        public bool IsCompressed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether the frame is read only
        /// </summary>
        public bool IsReadOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this frame will be preserved when the file is changed
        /// </summary>
        public bool PreserveOnFileChange
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this frame will be preserved when the tag is changed
        /// </summary>
        public bool PreserveOnTagChange
        {
            get;
            set;
        }
    }
}
