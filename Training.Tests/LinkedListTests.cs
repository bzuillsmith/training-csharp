using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Training.Tests
{
    [TestClass]
    public class LinkedListTests
    {
        private ILinkedList LinkedList { get; set; }

        [TestInitialize]
        public void Init()
        {
            LinkedList = new LinkedList();
        }

        [TestMethod]
        public void FirstAndLast_ShouldBeNullWhenThereAreNoItemsInTheList()
        {
            Assert.IsNull(LinkedList.First);
            Assert.IsNull(LinkedList.Last);
        }

        [TestMethod]
        public void Add_ShouldSetFirstAndLastToTheItemWhenItIsTheFirstItem()
        {
            LinkedList.Add(42);
            Assert.AreEqual(42, LinkedList.First.Value);
            Assert.AreEqual(LinkedList.First, LinkedList.Last);
        }

        [TestMethod]
        public void Add_ShouldAddAnItemToBeTheLastItemOfTheList()
        {
            LinkedList.Add(101);
            LinkedList.Add(42);
            Assert.AreEqual(101, LinkedList.First.Value);
            Assert.AreEqual(42, LinkedList.Last.Value);
        }

        [TestMethod]
        public void FirstDotNextShouldBeTheSecondNodeInAListOf2Nodes()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            Assert.IsNotNull(LinkedList.First.Next, "First.Next was null but should be the second node.");
            Assert.AreEqual(2, LinkedList.First.Next.Value, "First.Next is storing the wrong value");
        }

        [TestMethod]
        public void AllNodesShouldConnectToTheirFollowingNode()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);
            LinkedList.Add(4);
            LinkedList.Add(5);
            Assert.IsNotNull(LinkedList.First.Next, "First.Next was null but should be the second node.");
            Assert.AreEqual(2, LinkedList.First.Next.Value, "First.Next is assigned to a node with the wrong value.");
            Assert.AreEqual(LinkedList.Last, LinkedList.First.Next.Next.Next.Next, "All nodes should connect to the following node until Last is reached");
        }

        [TestMethod]
        public void Count_ShouldEqual0WhenTheListIsFirstCreated()
        {
            Assert.AreEqual(0, LinkedList.Count);
        }

        [TestMethod]
        public void Count_ShouldEqual1WhenTheListHasOneItem()
        {
            LinkedList.Add(42);
            Assert.AreEqual(1, LinkedList.Count);
        }

        [TestMethod]
        public void Count_ShouldEqual5WhenTheListHas5Items()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);
            LinkedList.Add(4);
            LinkedList.Add(5);
            Assert.AreEqual(5, LinkedList.Count);
        }

        [TestMethod]
        public void Find_ShouldReturnNullIfTheListIsEmpty()
        {
            Assert.IsNull(LinkedList.Find(1), "An empty list should return null when Find() is called");
        }

        [TestMethod]
        public void Find_ShouldReturnTheFirstNodeIfItsAMatch()
        {
            LinkedList.Add(3);
            var result = LinkedList.Find(3);
            Assert.AreEqual(LinkedList.First, result);
        }

        [TestMethod]
        public void Find_ShouldReturnTheTheCorrectNodeInAListOf2Nodes()
        {
            LinkedList.Add(3);
            LinkedList.Add(6);
            Assert.AreEqual(LinkedList.First, LinkedList.Find(3));
            Assert.AreEqual(LinkedList.Last, LinkedList.Find(6));
        }

        [TestMethod]
        public void Find_ShouldReturnTheTheCorrectNodeInAListOfMoreThan2Nodes()
        {
            LinkedList.Add(3);
            LinkedList.Add(6);
            LinkedList.Add(9);
            LinkedList.Add(12);
            Assert.AreEqual(LinkedList.First.Next.Next, LinkedList.Find(9));
        }

        [TestMethod]
        public void Remove_ShouldThrowAnExceptionWhenAttemptingToRemoveAnItemFromAnEmptyList()
        {
            Assert.ThrowsException<InvalidOperationException>(() => LinkedList.Remove(4),
                "Attempting to remove an item from an empty list should throw an exception.");
        }

        [TestMethod]
        public void Remove_ShouldBeAbleToRemoveTheFirstItemInTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);

            LinkedList.Remove(1);

            Assert.AreEqual(2, LinkedList.First.Value);
        }

        [TestMethod]
        public void Remove_ShouldBeAbleToRemoveAnItemFromTheMiddleOfTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(4);
            LinkedList.Add(10);
            LinkedList.Add(3);

            LinkedList.Remove(4);

            Assert.AreNotEqual(4, LinkedList.First.Next.Next.Value);
        }

        [TestMethod]
        public void Remove_ShouldBeAbleToRemoveAnItemFromTheEndOfTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(4);
            LinkedList.Add(10);
            LinkedList.Add(3);

            LinkedList.Remove(3);

            Assert.AreNotEqual(3, LinkedList.Last.Value);
            Assert.AreEqual(10, LinkedList.Last.Value);
        }

        [TestMethod]
        public void Remove_ShouldThrowAnExceptionWhenAttemptingToRemoveAnItemNotInTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);

            Assert.ThrowsException<InvalidOperationException>(() => LinkedList.Remove(4), "Attempting to remove an item not in the list should throw an exception.");
        }

        [TestMethod]
        public void InsertAt_ShouldInsertItemAtASpecificIndex()
        {
            LinkedList.Add(9);
            LinkedList.Add(6);
            LinkedList.Add(5);

            LinkedList.InsertAt(2, 3);
            var item = LinkedList.First.Next.Next;
            Assert.AreEqual(3, item.Value);
        }

        [TestMethod]
        public void InsertAt_ShouldInsertItemAtFirstIndex()
        {
            LinkedList.Add(9);
            LinkedList.Add(6);
            LinkedList.Add(5);

            LinkedList.InsertAt(0, 10);
            var item = LinkedList.First;
            Assert.AreEqual(10, item.Value);
        }

        [TestMethod]
        public void InsertAt_ShouldInsertItemAtLastIndex()
        {
            LinkedList.Add(9);
            LinkedList.Add(6);
            LinkedList.Add(5);

            LinkedList.InsertAt(3, 3);
            var item = LinkedList.Last;
            Assert.AreEqual(3, item.Value);
        }

        [TestMethod]
        public void InsertAt_ShouldThrowAnExceptionWhenAttemptingToInsertAnItemAtAnIndexOutOfRange()
        {
            Assert.ThrowsException<IndexOutOfRangeException>(() => LinkedList.InsertAt(-1, 1),
                "Index is out of range should throw an exception");
        }

        [TestMethod]
        public void InsertAt_ShouldThrowAnExceptionWhenAttemptingToInsertAnItemToAnEmptyList()
        {
            Assert.ThrowsException<ArgumentNullException>(() => LinkedList.InsertAt(0, 1),
                "Attempting to insert and item to an empty list.");
        }
    }
}
