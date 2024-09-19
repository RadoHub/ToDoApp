using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.ValueObejts;

namespace ToDoApp.Application.Queries.TodoItemQueries
{
    public class GetTodoItemsByPriorityQuery : IRequest<IEnumerable<TodoItemDto>>
    {
        public TodoPriority Priority { get; set; }
    }
}
