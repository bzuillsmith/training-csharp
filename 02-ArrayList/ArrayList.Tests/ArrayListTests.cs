using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Training02.Tests
{
    [TestClass]
    public class ArrayListTests
    {
        private ArrayList ArrayList;

        [TestInitialize]
        public void Init()
        {
            ArrayList = new ArrayList();
        }

        [TestMethod]
        public void Add_ShouldBeAbleToAddAnItemToAnEmptyArrayList()
        {
            // Act
            ArrayList.Add("a");

            // Assert
            Assert.AreEqual("[a,,,]", ArrayList.ToString());
        }

        [TestMethod]
        public void Add_ShouldBeAbleTo2ItemsToAnArrayList()
        {
            ArrayList.Add("a");
            
            // Act
            ArrayList.Add("b");

            // Assert
            Assert.AreEqual("[a,b,,]", ArrayList.ToString());
        }

        [TestMethod]
        public void Add_ShouldBeAbleToAdd5ItemsToAnArrayListAndSetTheCountProperly()
        {
            ArrayList.Add("a");
            ArrayList.Add("b");
            ArrayList.Add("c");
            ArrayList.Add("d");

            // Act
            ArrayList.Add("e");

            // Assert
            Assert.AreEqual("[a,b,c,d,e,,,]", ArrayList.ToString());
            Assert.AreEqual(4, ArrayList.Count);
        }

        [TestMethod]
        public void Add_ShouldBeAbleToAddNullStrings()
        {
            // Act
            ArrayList.Add(null);
            ArrayList.Add("a");
            ArrayList.Add("");
            ArrayList.Add("b");

            // Assert
            Assert.AreEqual("[,a,,b]", ArrayList.ToString());
            Assert.IsNull(ArrayList[0]);
            Assert.AreEqual(string.Empty, ArrayList[2]);
        }

        [TestMethod]
        public void IndexOf_ShouldReturnIndexOfItem()
        {
            // Arrange
            ArrayList.Add("a");
            ArrayList.Add("c");
            ArrayList.Add("b");

            // Act
            var index = ArrayList.IndexOf("b");

            // Assert
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void InsertAt_ShouldInsertAtLastIndex()
        {
            //insert at last index (just like add)

            //Arrange
            ArrayList.Add("a");
            ArrayList.Add("b");
            ArrayList.Add("c");

            // Act
            ArrayList.InsertAt(3, "d");

            // Assert
            Assert.AreEqual("[a,b,c,d]", ArrayList.ToString());
        }

        [TestMethod]
        public void InsertAt_ShouldInsertAtFirstIndex()
        {
            // insert at first index

            //Arrange
            ArrayList.Add("a");
            ArrayList.Add("b");
            ArrayList.Add("c");

            // Act
            ArrayList.InsertAt(0, "d");

            // Assert
            Assert.AreEqual("[d,a,b,c]", ArrayList.ToString());
        }

        [TestMethod]
        public void InsertAt_ShouldInsertInTheMiddle()
        {
            // somewhere in the middle of the existing data

            //Arrange
            ArrayList.Add("a");
            ArrayList.Add("b");
            ArrayList.Add("c");

            // Act
            ArrayList.InsertAt(1, "d");

            // Assert
            Assert.AreEqual("[a,d,b,c]", ArrayList.ToString());
        }

        [TestMethod]
        public void InsertAt_ShouldInsertAtSpecificIndexLastWhenArrayIsFull()
        {
            // insert at when the internal array is full

            //Arrange
            ArrayList.Add("a");
            ArrayList.Add("b");
            ArrayList.Add("c");
            ArrayList.Add("d");

            // Act
            ArrayList.InsertAt(2, "e");

            // Assert
            Assert.AreEqual("[a,b,e,c,d,,,]", ArrayList.ToString());
        }
    }
}