using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// Contains a list of events
    /// </summary>
    public class EventTimingCodes : BaseFrame, IList<TimingCode>
    {
        private List<TimingCode> _InnerList;

        public override string Name
        {
            get { return "ETCO"; }
        }

        /// <summary>
        /// Gets or sets the time stamp format
        /// </summary>
        public TimeStampFormat Format
        {
            get;
            set;
        }

        #region IList<TimingCode> Members

        public int IndexOf(TimingCode item)
        {
            return _InnerList.IndexOf(item);
        }

        public void Insert(int index, TimingCode item)
        {
            _InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _InnerList.RemoveAt(index);
        }

        public TimingCode this[int index]
        {
            get { return _InnerList[index]; }
            set { _InnerList[index] = value; }
        }

        #endregion

        #region ICollection<TimingCode> Members

        public void Add(TimingCode item)
        {
            _InnerList.Add(item);
        }

        public void Clear()
        {
            _InnerList.Clear();
        }

        public bool Contains(TimingCode item)
        {
            return _InnerList.Contains(item);
        }

        public void CopyTo(TimingCode[] array, int arrayIndex)
        {
            _InnerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _InnerList.Count; }
        }

        public bool Remove(TimingCode item)
        {
            return _InnerList.Remove(item);
        }

        #endregion

        #region IEnumerable<TimingCode> Members

        public IEnumerator<TimingCode> GetEnumerator()
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
