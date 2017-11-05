using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak_2;

namespace Zadatak_2Tests
{
    [TestClass()]
    public class TodoItemTests
    {

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem item = new TodoItem("a");
            item.MarkAsCompleted();
            Assert.IsTrue(item.IsCompleted);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = itemA;
            TodoItem itemC = new TodoItem("a");
            Assert.IsTrue(itemA.Equals(itemB));
            Assert.IsFalse(itemA.Equals(itemC));
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = itemA;
            TodoItem itemC = new TodoItem("a");
            Assert.AreEqual(itemA, itemB);
            Assert.AreNotEqual(itemA, itemC);
        }
    }
}