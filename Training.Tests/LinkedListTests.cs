﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void First_ShouldBeTheFirstItemWhenAListHas5Items()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);
            LinkedList.Add(4);
            LinkedList.Add(5);
            Assert.AreEqual(1, LinkedList.First.Value);
            Assert.AreEqual(5, LinkedList.Last.Value);
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
        public void Remove_ShouldThrowAnExceptionWhenAttemptingToRemoveAnItemFromAnEmptyList()
        {
            Assert.ThrowsException<InvalidOperationException>(() => LinkedList.Remove(4), "Attempting to remove an item not in the list should throw an exception.");
        }

        [TestMethod]
        public void Remove_ShouldBeAbleToRemoveTheFirstItemInTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);

            LinkedList.Remove(1);

            Assert.AreNotEqual(4, LinkedList.First.Value);
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
        }

        [TestMethod]
        public void Remove_ShouldThrowAnExceptionWhenAttemptingToRemoveAnItemNotInTheList()
        {
            LinkedList.Add(1);
            LinkedList.Add(2);
            LinkedList.Add(3);

            Assert.ThrowsException<InvalidOperationException>(() => LinkedList.Remove(4), "Attempting to remove an item not in the list should throw an exception.");
        }
    }
}