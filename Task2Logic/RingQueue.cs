using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class RingQueue<T>
    {
        #region fields
        private T[] _array;
        private int _head;
        private int _tail;
        private int _size;
        #endregion


        public int Count 
        {  
            get
            {
                return this._size;
            }            
        }
        

        #region public method
        public RingQueue()
        {
            _array = new T[100];
            _head = 0;
            _tail = 0;
            _size = 0;
        }
        public RingQueue(int size)
        {
            _array = new T[size];
            _head = 0;
            _tail = 0;
        }
     
        /// <summary>
        /// add element to queue
        /// </summary>
        /// <param name="value"></param>
        public virtual void Enqueue(T value)
        {
            if (this._size == this._array.Length)
            {
                int capacity = (int)((long)this._array.Length * 2);
                if (capacity < this._array.Length + 4)
                    capacity = this._array.Length + 4;
                this.SetCapacity(capacity);
            }
            this._array[this._tail] = value;
            this._tail = (this._tail + 1) % this._array.Length;
            this._size = this._size + 1;
        }

        /// <summary>
        /// erese element from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            T value = this._array[this._head];
            this._head = (this._head + 1) % this._array.Length;
            this._size = this._size - 1;
            return value;
        }
        /// <summary>
        /// get first element from queue
        /// </summary>
        /// <returns></returns>
        public virtual object Peek()
        {
            if (this.Count == 0)
                throw new InvalidOperationException("InvalidOperation_EmptyQueue");
            return this._array[this._head];
        }
        /// <summary>
        /// get element in queue by index
        /// </summary>
        /// <param name="i">index of element in queue</param>
        /// <returns></returns>
        internal object GetElement(int i)
        {
            return this._array[(this._head + i) % this._array.Length];
        }
        /// <summary>
        /// clear queue
        /// </summary>
        public void Clear()
        {
            if (this._head < this._tail)
            {
                Array.Clear((Array)this._array, this._head, this._size);
            }
            else
            {
                Array.Clear((Array)this._array, this._head, this._array.Length - this._head);
                Array.Clear((Array)this._array, 0, this._tail);
            }
            this._head = 0;
            this._tail = 0;
            this._size = 0;
        }
        #endregion

        #region private method
        /// <summary>
        /// resize queue
        /// </summary>
        /// <param name="capacity"></param>
        private void SetCapacity(int capacity)
        {
            T[] objArray = new T[capacity];
            if (this._size > 0)
            {
                if (this._head < this._tail)
                {
                    Array.Copy((Array)this._array, this._head, (Array)objArray, 0, this._size);
                }
                else
                {
                    Array.Copy((Array)this._array, this._head, (Array)objArray, 0, this._array.Length - this._head);
                    Array.Copy((Array)this._array, 0, (Array)objArray, this._array.Length - this._head, this._tail);
                }
            }
            this._array = objArray;
            this._head = 0;
            this._tail = this._size == capacity ? 0 : this._size;
        }
        #endregion
    }
}
