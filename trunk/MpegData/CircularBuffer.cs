using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MpegData
{
    /// <summary>
    /// A quick & dirty circular buffer
    /// </summary>
    public class CircularBuffer
    {
        private byte[] _Data;
        private int _WriteLocation;
        private int _ReadLocation;
        /// <summary>
        /// Gets the capacity of the buffer
        /// </summary>
        public int Capacity
        {
            get { return _Data.Length; }
        }

        /// <summary>
        /// Create a buffer with a given size
        /// </summary>
        /// <param name="capacity">size of the buffer</param>
        public CircularBuffer(int capacity)
        {
            _Data = new byte[capacity];
        }

        /// <summary>
        /// Create a buffer & initialise it
        /// </summary>
        /// <param name="data"></param>
        public CircularBuffer(byte[] data)
        {
            _Data = data;
        }

        /// <summary>
        /// Read a byte and advance though the buffer
        /// </summary>
        /// <returns>next byte value to be read</returns>
        public byte Read()
        {
            byte result = Peek();

            _ReadLocation++;
            if (_ReadLocation >= Capacity)
                _ReadLocation = 0;

            return result;
        }

        /// <summary>
        /// read the next byte without advancing though the buffer
        /// </summary>
        /// <returns></returns>
        public byte Peek()
        {
            return _Data[_ReadLocation];
        }

        /// <summary>
        /// Read the contents of the buffer starting at the current position
        /// </summary>
        /// <returns>contents of the buffer from the current read location</returns>
        public byte[] ReadAll()
        {
            byte[] Result = new byte[Capacity];
            if (_ReadLocation == 0)
            {
                _Data.CopyTo(Result, 0);
            }
            else
            {
                Array.Copy(_Data, _ReadLocation, Result, 0, Capacity - _ReadLocation);
                Array.Copy(_Data, 0, Result, Capacity - _ReadLocation, _ReadLocation);
            }

            return Result;
        }

        /// <summary>
        /// Write a byte to the buffer and advance position
        /// </summary>
        /// <param name="value">value to write</param>
        public void Write(byte value)
        {
            _Data[_WriteLocation] = value;

            _WriteLocation++;
            if (_WriteLocation >= Capacity)
                _WriteLocation = 0;
        }
    }
}
