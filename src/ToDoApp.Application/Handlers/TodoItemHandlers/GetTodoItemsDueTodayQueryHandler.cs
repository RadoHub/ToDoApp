using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Queries.TodoItemQueries;

namespace ToDoApp.Application.Handlers.TodoItemHandlers
{
    public class GetTodoItemsDueTodayQueryHandler : IRequestHandler<GetTodoItemsDueTodayQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetTodoItemsDueTodayQueryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetTodoItemsDueTodayQuery request, CancellationToken cancellationToken)
        {
            var items = await _todoItemRepository.GetTasksDueTodayAsync();
            return items.Select(x => new TodoItemDto
            {
                Id = x.Id,
                Description = x.Description,
                DueDate = x.DueDate,
                Priority = x.Priority,
                Status = x.Status,
                Title = x.Title
            });
        }
    }
}
