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
    }
}
