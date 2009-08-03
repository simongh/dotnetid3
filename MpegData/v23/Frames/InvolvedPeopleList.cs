using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// A list of involved persons not stored elsewhere
    /// </summary>
    public class InvolvedPeopleList : BaseTextFrame, IList<InvolvedPerson>
    {
        private List<InvolvedPerson> _InnerList;

        public override string Name
        {
            get { return "IPLS"; }
        }

		internal InvolvedPeopleList(FrameCollection frames)
			: base(frames)
		{ }

        #region IList<InvolvedPerson> Members

        public int IndexOf(InvolvedPerson item)
        {
            return _InnerList.IndexOf(item);
        }

        public void Insert(int index, InvolvedPerson item)
        {
            _InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _InnerList.RemoveAt(index);
        }

        public InvolvedPerson this[int index]
        {
            get { return _InnerList[index]; }
            set { _InnerList[index] = value; }
        }

        #endregion

        #region ICollection<InvolvedPerson> Members

        public void Add(InvolvedPerson item)
        {
            _InnerList.Add(item);
        }

        public void Clear()
        {
            _InnerList.Clear();
        }

        public bool Contains(InvolvedPerson item)
        {
            return _InnerList.Contains(item);
        }

        public void CopyTo(InvolvedPerson[] array, int arrayIndex)
        {
            _InnerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _InnerList.Count; }
        }

        public bool Remove(InvolvedPerson item)
        {
            return _InnerList.Remove(item);
        }

        #endregion

        #region IEnumerable<InvolvedPerson> Members

        public IEnumerator<InvolvedPerson> GetEnumerator()
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

		internal override void ParseBody(byte[] data)
		{
			throw new NotImplementedException();
		}

		protected override byte[] BodyToArray()
		{
			throw new NotImplementedException();
		}
	}
}
