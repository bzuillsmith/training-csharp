using System;

namespace Training02
{
    /// <summary>
    /// Arrays are nice for quick access and simple storage of data; however, arrays can't grow automatically.
    /// If you create an array of size 4 (like below), it can't have more than 4 items in it.
    /// This is where ArrayList comes in. ArrayList is a data structure that wraps around a regular array and
    /// occasionally "resizes" the array. Resizing is really a copy operation into a new, bigger array. For our
    /// ArrayList, we will double the array size anytime we need to resize it.
    /// </summary>
    public class ArrayList : IArrayList
    {
        string[] _internalArray = new String[4];

        public int Count { get; private set; }

        /// <summary>
        /// Add will put the given item into the array at the "last" spot. That is, the first item, goes in
        /// index 0, the second item in index 1, etc. However, the internal array may have more spaces than that.
        /// This means you need to use Count to keep track of the number of items and from there, you can figure
        /// the last index where you should put items. When the internal array is full, you must increase the size
        /// before trying to put the item into it or you'll get an IndexOutOfBoundsException.
        /// </summary>
        /// <param name="item"></param>
        public void Add(string item)
        {
            // TODO: place new items in the next open spot in the internal array. 
            if (Count < _internalArray.Length)
            {
                _internalArray[Count] = item;
                Count += 1;
            }
            // If there is no more space in the internal array
            else
            {
                // call DoubleArraySize before insterting the item.
                DoubleArraySize();
                _internalArray[Count] = item;
            }
        }

        private void DoubleArraySize()
        {
            // TODO: Write your code to double the size of the array here. 
            // Create a new array and copy the current contents into the new array.
            string[] _newInternalArray = new String[_internalArray.Length * 2];
            
            // Loop until index is less/equal than the array index
            for (var i = 0; i <= _internalArray.Length - 1; i++)
            {
                _newInternalArray[i] = _internalArray[i];
            }

            _internalArray = _newInternalArray;
        }

        /// <summary>
        /// Finds the item in the ArrayList and returns the index it was found at.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(string item)
        {
            int index = 0;

            for (var i = 0; i <= _internalArray.Length - 1; i++)
            {
                if (_internalArray[i] == item)
                {
                    index = i;
                }
            }
            return index;
        }

        /// <summary>
        /// Inserts an item at the given index.
        /// </summary>
        /// <remarks>
        /// You can't just put the item in between to existing spots of an array. Instead, you'll need
        /// to take all the items after the insert point, save them in a temporary array, put the new
        /// item in the correct spot, then "paste" all the items that came after the insert point, back
        /// into the array (they will all have an index that is 1 greater than the index they were at
        /// before).
        /// </remarks>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void InsertAt(int index, string item)
        {
            throw new NotImplementedException();
        }

        public void Remove(string item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// To string method which is helpful for testing and debugging.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{string.Join(",", _internalArray)}]";
        }

        public string this[int i]
        {
            get
            {
                if (i > Count - 1) throw new IndexOutOfRangeException();
                return _internalArray[i];
            }
            set
            {
                if (i > Count - 1) throw new IndexOutOfRangeException();
                _internalArray[i] = value;

            }
        }
    }
}
