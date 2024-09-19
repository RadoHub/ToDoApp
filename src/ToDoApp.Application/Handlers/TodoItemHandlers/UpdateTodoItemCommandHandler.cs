using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.TodoItemCommands;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;

namespace ToDoApp.Application.Handlers.TodoItemHandlers
{
    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, bool>
    {
        private readonly ITodoItemRepository _repository;

        public UpdateTodoItemCommandHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdAsync(request.Id);
            if (todoItem == null)
            {
                throw new BadRequestException($"Item {nameof(todoItem)} cannot be updated");    
            }
            todoItem.UpdateDetails(request.Title, request.Description, request.DueDate, request.Priority);
            todoItem.UpdateStatus(request.Status);

            await _repository.UpdateAsync(todoItem);
            return true;
        }
    }
}
