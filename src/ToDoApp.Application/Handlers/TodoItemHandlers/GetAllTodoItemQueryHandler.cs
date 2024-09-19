using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Queries.TodoItemQueries;

namespace ToDoApp.Application.Handlers.TodoItemHandlers
{
    public class GetAllTodoItemQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemDto>>
    {
        private readonly ITodoItemRepository _repository;

        public GetAllTodoItemQueryHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _repository.GetAllAsync();

            if (todoItems == null)
            {
                throw new NotFoundException("There is not any single data to be listed");
            }
            return todoItems.Select(x => new TodoItemDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                Priority = x.Priority,
                Status = x.Status,
                TodoGroupId = x.TodoGroupId
            });
        }
    }
}
