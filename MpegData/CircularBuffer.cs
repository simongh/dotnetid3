using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData
{
    public class CircularBuffer
    {
        private byte[] _Data;
        private int _Location;

        public int Capacity
        {
            get { return _Data.Length; }
        }

        public CircularBuffer(int capacity)
        {
            _Data = new byte[capacity];
            _Location = -1;
        }

        public CircularBuffer(byte[] data)
        {
            _Data = data;
        }

        public byte Read()
        {
            return _Data[_Location];
        }

        public byte[] ReadAll()
        {
            byte[] Result = new byte[Capacity];
            if (_Location + 1 >= Capacity)
            {
                _Data.CopyTo(Result, 0);
            }
            else
            {
                _Data.CopyTo(Result, _Location + 1);

                Array.Copy(_Data, 0, Result, Capacity - _Location + 1, _Location);
            }

            return Result;
        }

        public void Write(byte value)
        {
            _Data[_Location] = value;

            _Location++;
            if (_Location >= Capacity)
                _Location = 0;
        }
    }
}
