using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Describes the purchase of the file
    /// </summary>
    public class Ownership : BaseTextFrame
    {
        public override string Name
        {
            get { return "OWNE"; }
        }

        /// <summary>
        /// Gets or sets the currency of the purchase as a 3 letter ISO-4217 code
        /// </summary>
        public string Currency
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the purchase price
        /// </summary>
        public float PricePaid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date of the purchase
        /// </summary>
        public DateTime DatePurchased
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the sellers name
        /// </summary>
        public string Seller
        {
            get;
            set;
        }
    }
}
