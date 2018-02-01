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
            if (First != null)
            {
                var newNode = new LinkedListNode();
                Last.Next = newNode;
                Last = newNode;
                newNode.Value = item;
            }
            else
            {
                First = new LinkedListNode();
                First.Value = item;
                Last = First;
            }
            Count += 1;
        }

        public LinkedListNode Find(int value)
        {
            // If the LinkedList is empty, return nothing
            if (First == null) return null;

            /// Create a new pointer
            LinkedListNode temp = null;

            // Point that pointer to the First node
            temp = First;

            // While temp is not pointing to the last node
            while (temp != null)
            {
                // If the value inside temp no is the value we're looking for
                if (temp.Value == value)
                {
                    // Return it
                    return temp;
                }

                // Reconnect the linked list
                temp = temp.Next;
            }

            return null;
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
            if (First != null)
            {
                //Find the node with the item
                LinkedListNode previous = null;

                LinkedListNode current = null;
                current = First;

                while (current != null)
                {
                    // Check if current is what we are looking for
                    if (current.Value == item)
                    {
                        // If we are at the first node then just change First to next node.
                        if (First == current)
                        {
                            First = First.Next;
                            return;
                        }

                        // Redirect previous to what is after current
                        previous.Next = current.Next;

                        // if the previous node next property points to nothing, it is the last node now
                        if(previous.Next == null)
                        {
                            // Point Last node to previous node
                            Last = previous;
                        }

                        return;
                    }
                    // else lets move to the next node
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }

                if (current == null)
                {
                    throw new InvalidOperationException("Attempting to remove an item not in the list should throw an exception.");
                }
            }
            else
            {
                throw new InvalidOperationException("Attempting to remove an item from an emtpy list should throw an exception.");
            }

            // Update Count
            Count -= 1;
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
