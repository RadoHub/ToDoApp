using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Queries.GetTodoItem;

namespace ToDoApp.Application.Handlers.TodoItemHandlers
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, TodoItemDto>
    {
        private readonly ITodoItemRepository _repository;

        public GetTodoItemQueryHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItemDto> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdAsync(request.Id);
            return new TodoItemDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                DueDate = todoItem.DueDate,
                Priority = todoItem.Priority,
                Status = todoItem.Status,

            };
        }
    }
}
