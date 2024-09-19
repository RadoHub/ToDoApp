using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;

namespace ToDoApp.Application.Queries.TodoItemQueries
{
    public class GetTodoItemsDueTodayQuery : IRequest<IEnumerable<TodoItemDto>>
    {
    }
}
