using System;

namespace Training02
{
    /// <summary>
    /// Arrays are nice for quick access and simple storage of data; however, arrays can't grow automatically.
    /// This is where ArrayList comes in. ArrayList is a data structure that wraps around a regular array and
    /// occasionally "resizes" the array. Resizing is really a copy operation into a new, bigger array. For our
    /// ArrayList, we will double the array size anytime we need to resize it.
    /// </summary>
    public class ArrayList : IArrayList
    {
        string[] _internalArray = new String[4];

        public int Count => throw new NotImplementedException();

        public void Add(string item)
        {
            // TODO: place the item in the next open spot in the internal array. If there is no more space
            //       in the internal array, call DoubleArraySize before insterting the item.
            _internalArray[0] = item;
        }

        private void DoubleArraySize()
        {
            // TODO: Write your code to double the size of the array here. Create a new array and 
            //       copy the current contents into the new array.
        }

        public int IndexOf(string item)
        {
            throw new NotImplementedException();
        }

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
    }
}
