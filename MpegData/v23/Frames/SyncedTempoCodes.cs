using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    public class SyncedTempoCodes : BaseFrame, IList<TempoCode>
    {
        private List<TempoCode> _InnerList;

        public override string Name
        {
            get { return "SYTC"; }
        }

        /// <summary>
        /// Gets or sets the time stamp format
        /// </summary>
        public TimeStampFormat Format
        {
            get;
            set;
        }

        #region IList<TempoCode> Members

        public int IndexOf(TempoCode item)
        {
            return _InnerList.IndexOf(item);
        }

        public void Insert(int index, TempoCode item)
        {
            _InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _InnerList.RemoveAt(index);
        }

        public TempoCode this[int index]
        {
            get { return _InnerList[index]; }
            set { _InnerList[index] = value; }
        }

        #endregion

        #region ICollection<TempoCode> Members

        public void Add(TempoCode item)
        {
            _InnerList.Add(item);
        }

        public void Clear()
        {
            _InnerList.Clear();
        }

        public bool Contains(TempoCode item)
        {
            return _InnerList.Contains(item);
        }

        public void CopyTo(TempoCode[] array, int arrayIndex)
        {
            _InnerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _InnerList.Count; }
        }

        public bool Remove(TempoCode item)
        {
            return _InnerList.Remove(item);
        }

        #endregion

        #region IEnumerable<TempoCode> Members

        public IEnumerator<TempoCode> GetEnumerator()
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
