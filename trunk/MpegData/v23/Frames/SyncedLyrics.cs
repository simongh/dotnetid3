using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// An individual piece of synced text, usually a syllable
    /// </summary>
    public struct SyncText : IComparable<SyncText>
    {
        private string _Text;
        private long _TimeStamp;

        /// <summary>
        /// Gets or sets the text for this sync point
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the timestamp for this sync
        /// </summary>
        public long TimeStamp
        {
            get { return _TimeStamp; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("A timestamp should be greater than zero.");

                _TimeStamp = value;
            }
        }

        #region IComparable<SyncText> Members

        public int CompareTo(SyncText other)
        {
            return this.TimeStamp.CompareTo(other.TimeStamp);
        }

        #endregion
    }

    /// <summary>
    /// Holds lyrics/text synced to the audio
    /// </summary>
    public class SyncedLyrics : LanguageFrame, IList<SyncText>
    {
        private List<SyncText> _InnerList;

        public override string Name
        {
            get { return "SYLT"; }
        }

        internal override string UniqueId
        {
            get { return Name + Language + Descriptor; }
        }

        /// <summary>
        /// Gets or sets the format of the timestamps
        /// </summary>
        public TimeStampFormat Format
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the text
        /// </summary>
        public TextContentType ContentType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the description of this text
        /// </summary>
        public string Descriptor
        {
            get;
            set;
        }

        #region IList<SyncText> Members

        public int IndexOf(SyncText item)
        {
            return _InnerList.IndexOf(item);
        }

        public void Insert(int index, SyncText item)
        {
            _InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _InnerList.RemoveAt(index);
        }

        public SyncText this[int index]
        {
            get { return _InnerList[index]; }
            set { _InnerList[index] = value; }
        }

        #endregion

        #region ICollection<SyncText> Members

        public void Add(SyncText item)
        {
            _InnerList.Add(item);
        }

        public void Clear()
        {
            _InnerList.Clear();
        }

        public bool Contains(SyncText item)
        {
            return _InnerList.Contains(item);
        }

        public void CopyTo(SyncText[] array, int arrayIndex)
        {
            _InnerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _InnerList.Count; }
        }

        public bool Remove(SyncText item)
        {
            return _InnerList.Remove(item);
        }

        #endregion

        #region IEnumerable<SyncText> Members

        public IEnumerator<SyncText> GetEnumerator()
        {
            return _InnerList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _InnerList.GetEnumerator();
        }

        #endregion
    }
}
