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
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, bool>
    {
        private readonly ITodoItemRepository _repository;

        public DeleteTodoItemCommandHandler(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _repository.GetByIdAsync(request.Id);
            if (todoItem == null)
            {
                throw new NotFoundException(nameof(todoItem), request.Id);
            }
            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
