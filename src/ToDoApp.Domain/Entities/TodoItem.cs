using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ToDoApp.Domain.ValueObejts;

namespace ToDoApp.Domain.Entities
{
    
    public class TodoItem
    {
        //private constructor
        private TodoItem() { }


        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public TodoStatus Status { get; private set; }
        public TodoPriority Priority { get; private set; }
        public Guid? TodoGroupId { get; set; }
        public  TodoGroup TodoGroup { get; set; }


        public TodoItem (string title, string description, DateTime dueDate, TodoPriority priority, Guid? todoGroupId=null )
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = TodoStatus.Pending;
            Priority = priority;
            TodoGroupId = todoGroupId;
        }

        public void MarkAsCompleted()
        {
            Status = TodoStatus.Completed;
        }

        public void UpdateStatus(TodoStatus newStatus)
        {
            Status = newStatus;
        }

        public void UpdateDetails(string title, string description, DateTime dueDate, TodoPriority priority)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}
