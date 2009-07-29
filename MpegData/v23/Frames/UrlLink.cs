using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Defines a URL link to further information
    /// </summary>
    public class UrlLink : BaseFrame
    {
        public override string Name
        {
            get 
            {
                switch (LinkType)
                {
                    case UrlLinkType.Commercial:
                        return "WCOM";
                    case UrlLinkType.Copyright:
                        return "WCOP";
                    case UrlLinkType.AudioFile:
                        return "WOAF";
                    case UrlLinkType.Artist:
                        return "WOAR";
                    case UrlLinkType.AudioSource:
                        return "WOAS";
                    case UrlLinkType.InternetRadioHome:
                        return "WORS";
                    case UrlLinkType.Payment:
                        return "WPAY";
                    case UrlLinkType.Publisher:
                        return "WPUB";
                    default:
                        throw new ArgumentException("An unknown Link type was specified.");
                }
            }
        }

        internal override string UniqueId
        {
            get
            {
                switch (LinkType)
                {
                    case UrlLinkType.Commercial:
                    case UrlLinkType.Artist:
                        return Name + Url;
                    default:
                        return base.UniqueId;
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of link this is.
        /// </summary>
        public UrlLinkType LinkType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the url for this link.
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        public UrlLink(UrlLinkType linkType)
            : base()
        {
            LinkType = linkType;
        }
    }
}
