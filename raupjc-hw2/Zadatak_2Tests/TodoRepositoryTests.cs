using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadatak_2;
using Zadatak_3;

namespace Zadatak_2Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        
        [TestMethod()]
        public void GetTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem item = new TodoItem("a");
            list.Add(item);
            TodoRepository repository = new TodoRepository(list);
            Assert.AreEqual(item, repository.Get(item.Id));
        }

        [TestMethod()]
        public void AddTest()
        {
            TodoItem item = new TodoItem("a");
            TodoRepository repository = new TodoRepository(null);
            Assert.AreEqual(item, repository.Add(item));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoItem item = new TodoItem("a");
            TodoRepository repository = new TodoRepository(null);
            repository.Add(item);
            Assert.IsTrue(repository.Remove(item.Id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoItem item = new TodoItem("a");
            TodoRepository repository = new TodoRepository(null);
            repository.Add(item);
            TodoItem newItem = new TodoItem("b") {Id = item.Id};
            repository.Update(newItem);
            Assert.AreEqual(newItem, repository.Get(item.Id));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem item = new TodoItem("a");
            TodoRepository repository = new TodoRepository(null);
            repository.Add(item);
            Assert.IsTrue(repository.Get(item.Id).MarkAsCompleted());
        }

        [TestMethod()]
        public void GetAllTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = new TodoItem("b");

            list.Add(itemA);
            list.Add(itemB);
            TodoRepository repository = new TodoRepository(list);

            CollectionAssert.AreEqual(list.ToList(), repository.GetAll());
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = new TodoItem("b");
            itemB.MarkAsCompleted();
            list.Add(itemA);
            list.Add(itemB);
            TodoRepository repository = new TodoRepository(list);

            foreach (TodoItem item in repository.GetCompleted())
            {
                Assert.AreNotEqual(item, itemA);
                Assert.AreEqual(item, itemB);
            }
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = new TodoItem("b");
            itemB.MarkAsCompleted();
            list.Add(itemA);
            list.Add(itemB);
            TodoRepository repository = new TodoRepository(list);

            foreach (TodoItem item in repository.GetActive())
            {
                Assert.AreNotEqual(item, itemB);
                Assert.AreEqual(item, itemA);
            }
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            IGenericList<TodoItem> list = new GenericList<TodoItem>();
            TodoItem itemA = new TodoItem("a");
            TodoItem itemB = new TodoItem("b");
            itemB.MarkAsCompleted();
            list.Add(itemA);
            list.Add(itemB);
            TodoRepository repository = new TodoRepository(list);
            foreach (TodoItem item in repository.GetFiltered(s => s.Text.Equals("b")))
            {
                Assert.AreEqual(item, itemB);
                Assert.AreNotEqual(item, itemA);
            }
        }
    }
}