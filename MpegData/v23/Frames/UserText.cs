using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Allows storing user defined text 
    /// </summary>
    public class UserText: BaseTextFrame 
    {
        public override string Name
        {
            get { return "TXXX"; }
        }

        internal override string UniqueId
        {
            get { return Name + Description; }
        }

        /// <summary>
        /// Gets or sets the description of the text
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        public string Text
        {
            get;
            set;
        }
    }
}
