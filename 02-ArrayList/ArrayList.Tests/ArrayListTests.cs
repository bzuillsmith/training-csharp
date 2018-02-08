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
    }
}
