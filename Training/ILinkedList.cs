namespace Training
{
    public interface ILinkedList
    {
        /// <summary>
        /// The number of items in the list.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <param name="item"></param>
        void Add(int item);

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="item"></param>
        void InsertAt(int index, int item);

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="item"></param>
        void Remove(int item);

        /// <summary>
        /// Finds the first node that has the given value
        /// </summary>
        /// <param name="value"></param>
        LinkedListNode Find(int value);

        /// <summary>
        /// Finds the last node that has the given value
        /// </summary>
        /// <param name="value"></param>
        LinkedListNode FindLast(int value);

        /// <summary>
        /// Gets the first node in the list
        /// </summary>
        LinkedListNode First { get; }

        /// <summary>
        /// Gets the last node in the list
        /// </summary>
        LinkedListNode Last { get; }
    }
}