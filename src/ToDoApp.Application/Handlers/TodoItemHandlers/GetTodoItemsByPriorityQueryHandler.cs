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
    public class GetTodoItemsByPriorityQueryHandler : IRequestHandler<GetTodoItemsByPriorityQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetTodoItemsByPriorityQueryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetTodoItemsByPriorityQuery request, CancellationToken cancellationToken)
        {
            var items = await _todoItemRepository.GetTasksByPriorityAsync(request.Priority);
            return items.Select(x => new TodoItemDto
            {
                Priority = x.Priority,
                Description = x.Description,
                DueDate = x.DueDate,
                Id = x.Id,
                Status = x.Status,
                Title = x.Title,
            });
        }
    }
}
