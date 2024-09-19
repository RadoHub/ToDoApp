using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.CreateTodoItem;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;


namespace ToDoApp.Application.Handlers.TodoItemHandlers
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Guid>
    {
        private readonly ITodoItemRepository _todoRepository;

        public CreateTodoItemCommandHandler(ITodoItemRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Guid> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem(request.Title, request.Description, request.DueDate, request.Priority, request.TodoGroupId);

            try
            {
                await _todoRepository.AddAsync(todoItem);
                
            }

            catch (Exception ex)
            {
                throw new BadRequestException($"Cannot create Todo Item : {ex.Message}");
            }
            return todoItem.Id;
        }
    }
}
