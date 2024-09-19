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
    public class GetTodoItemsByGroupQueryHandler : IRequestHandler<GetTodoItemsByGroupQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public GetTodoItemsByGroupQueryHandler(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetTodoItemsByGroupQuery request, CancellationToken cancellationToken)
        {
            var items = await _todoItemRepository.GetByGroupIdAsync(request.GroupId);
            return items.Select(x => new TodoItemDto {
            Description = x.Description,
            DueDate = x.DueDate,
            Id = x.Id,
            Priority = x.Priority,
            Status = x.Status,
            Title  = x.Title            
            });
        }
    }
}
