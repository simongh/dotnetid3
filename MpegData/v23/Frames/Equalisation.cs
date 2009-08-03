using System;
using System.Collections.Generic;
using System.Text;

namespace MpegData.v23.Frames
{
    /// <summary>
    /// A list of equalisations
    /// </summary>
    public class Equalisation : BaseFrame, IList<EqualisationSettting>
    {
        private int _AdjustmentSize;
        private List<EqualisationSettting> _InnerList;

        public override string Name
        {
            get { return "EQUA"; }
        }

        /// <summary>
        /// Gets or sets the size of the equalisation adjustments
        /// </summary>
        public int AdjustmentSize
        {
            get { return _AdjustmentSize; }
            set
            {
                if (value < 1 || value > 63)
                    throw new ArgumentOutOfRangeException("The adjustment size must be in the range 1-63");

				_AdjustmentSize = value;
            }
        }

		internal Equalisation(FrameCollection frames)
			: base(frames)
		{ }

        #region IList<Frequency> Members

        public int IndexOf(EqualisationSettting item)
        {
            return _InnerList.IndexOf(item);
        }

        public void Insert(int index, EqualisationSettting item)
        {
            _InnerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _InnerList.RemoveAt(index);
        }

        public EqualisationSettting this[int index]
        {
            get { return _InnerList[index]; }
            set { _InnerList[index] = value; }
        }

        #endregion

        #region ICollection<Frequency> Members

        public void Add(EqualisationSettting item)
        {
            _InnerList.Add(item);
        }

        public void Clear()
        {
            _InnerList.Clear();
        }

        public bool Contains(EqualisationSettting item)
        {
            return _InnerList.Contains(item);
        }

        public void CopyTo(EqualisationSettting[] array, int arrayIndex)
        {
            _InnerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _InnerList.Count; }
        }

        public bool Remove(EqualisationSettting item)
        {
            return _InnerList.Remove(item);
        }

        #endregion

        #region IEnumerable<Frequency> Members

        public IEnumerator<EqualisationSettting> GetEnumerator()
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
