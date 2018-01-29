using System;

namespace Training
{
    public class LinkedList : ILinkedList
    {
        public LinkedListNode First { get; private set; }
        public LinkedListNode Last { get; private set; }

        public int Count { get; private set; }

        public void Add(int item)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode Find(int value)
        {
            throw new NotImplementedException();
        }

        public LinkedListNode FindLast(int value)
        {
            throw new NotImplementedException();
        }

        public void InsertAt(int item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int item)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// A contianer for a single value in the LinkedList
    /// </summary>
    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next;
    }
}
