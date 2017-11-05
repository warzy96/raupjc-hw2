using System;
using System.Collections.Generic;
using System.Linq;
using Zadatak_3;

namespace Zadatak_2
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excercise.
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId) =>_inMemoryTodoDatabase.FirstOrDefault(s => s.Id == todoId);
        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
                throw new DuplicateTodoItemException("duplicate id: " + todoItem.Id);
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId) =>
            _inMemoryTodoDatabase.Remove(Get(todoId));

        public TodoItem Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                TodoItem existingItem = Get(todoItem.Id);
                existingItem.DateCompleted = todoItem.DateCompleted;
                existingItem.DateCreated = todoItem.DateCreated;
                existingItem.Text = todoItem.Text;
                return existingItem;
            }
            return Add(todoItem);
        }

        public bool MarkAsCompleted(Guid todoId) => Get(todoId).MarkAsCompleted();

        public List<TodoItem> GetAll() 
            => _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();

        public List<TodoItem> GetActive() 
            => _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();

        public List<TodoItem> GetCompleted() 
            => _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
            => _inMemoryTodoDatabase.Where(filterFunction).ToList();
    }
}