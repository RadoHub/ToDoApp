using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.DTOs
{
    public class TodoGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<TodoItemDto> Items { get; set; } = new List<TodoItemDto>();
    }
}
