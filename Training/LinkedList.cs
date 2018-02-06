using System;
using System.Text;

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
            LinkedListNode current = null;

            // Point that pointer to the First node
            current = First;

            // While temp is not pointing to the last node
            while (current != null && current.Value != value)
            {
                // Reconnect the linked list
                current = current.Next;
            }

            return current;
        }

        public LinkedListNode FindLast(int value)
        {
            // If the LinkedList is empty, return nothing
            if (First == null) return null;

            // Set pointers
            LinkedListNode nodeToRemember = null;
            LinkedListNode currentNode = First;

            // Set counter
            var count = 0;

            // Keep looping as long as the current is not pointing at the last node
            while (currentNode.Next != null)
            {
                // When the current node contains a value matching the value passed in
                if(currentNode.Value == value)
                {
                    // Point nodeToRemember to that node current is pointed to
                    nodeToRemember = currentNode;
                    count += 1;
                }
                // Move on to the next node
                currentNode = currentNode.Next;
            }

            // When there is only one node in the list
            if (currentNode == First)
            {
                // Point nodeToRemember to that node current is pointed to
                nodeToRemember = currentNode;
            }

            return nodeToRemember;
        }

        public void InsertAt(int index, int item)
        {
            // If index is less than zero throw out exception.
            if (index < 0) throw new IndexOutOfRangeException("Index is out of range should throw an exception");

            // If the list is empty
            if (First == null) throw new ArgumentNullException("Attempting to insert and item to an empty list.");

            // Set pointers
            LinkedListNode currentNode = null;
            LinkedListNode newNode = new LinkedListNode();
            newNode.Value = item;

            // Set current index
            var currentIndex = 0;

            if (First != null)
            {
                // Point currentNode the First node in list
                currentNode = First;

                // When inserting item at first index
                if (index == 0)
                {                  
                    First = newNode;
                    newNode.Next = currentNode;
                    return;
                }

                // When inserting item in between first and last index
                while (currentIndex != index - 1)
                {
                    // move to the next node
                    currentNode = currentNode.Next;
                    currentIndex += 1;
                }

                Count += 1;

                // When inserting item at last index
                if(Last == currentNode)
                {
                    // Point currentNode at end of list to newNode 
                    currentNode.Next = newNode;
                    // Point Last from where currentNode to newNode
                    Last = newNode;
                    return;
                }

                // Point newNode.Next to same node where current.Next is pointing to avoiding a lost node
                newNode.Next = currentNode.Next;

                // Point newNode.Next to the newNode inserting it in between the proceeding node
                currentNode.Next = newNode;
            }
            else
            {
                throw new InvalidOperationException("Attempting to instert an item in an empty list should throw an exception.");
            }
        }

        public void Remove(int item)
        {
            if (First != null)
            {
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            var current = this.First;
            while (current != null)
            {
                sb.Append(current.ToString());
                sb.Append(",");
                current = current.Next;
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");

            return sb.ToString();
        }
    }

    /// <summary>
    /// A contianer for a single value in the LinkedList
    /// </summary>
    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
