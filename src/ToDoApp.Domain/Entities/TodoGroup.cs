using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.Entities
{
    public class TodoGroup
    {
        public Guid Id { get; private  set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }

        private  List<TodoItem> _items;
        public IReadOnlyCollection<TodoItem> Items => _items.AsReadOnly();

        private TodoGroup()
        {
            _items = new List<TodoItem>();
        }

        public TodoGroup (string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            CreationDate = DateTime.UtcNow;
            _items = new List<TodoItem>();
        }

        public void AddItem ( TodoItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(TodoItem item)
        {
            _items.Remove(item);
        }

        public void UpdateItem(string   newName)
        {
            Name = newName;
        }
    }
}
