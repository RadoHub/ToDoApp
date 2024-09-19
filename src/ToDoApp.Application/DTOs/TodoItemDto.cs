using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.ValueObejts;

namespace ToDoApp.Application.DTOs
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TodoStatus  Status { get; set; }
        public TodoPriority Priority { get; set; }
        public Guid? TodoGroupId { get; set; }
    }
}
