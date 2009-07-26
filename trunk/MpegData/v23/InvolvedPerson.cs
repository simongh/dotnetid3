using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23
{
    /// <summary>
    /// An involved person
    /// </summary>
    public struct InvolvedPerson
    {
        private string _Involvement;
        private string _Name;

        /// <summary>
        /// Gets or sets the type of involvement
        /// </summary>
        public string Involvement
        {
            get { return _Involvement; }
            set { _Involvement = value; }
        }

        /// <summary>
        /// Gets or sets the name of the person
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public InvolvedPerson(string name, string involement)
        {
            _Name = name;
            _Involvement = involement;
        }
    }
}
