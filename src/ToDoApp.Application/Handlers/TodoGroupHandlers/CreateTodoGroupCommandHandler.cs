using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.ToDoGroupCommands;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Handlers.TodoGroupHandlers
{
    public class CreateTodoGroupCommandHandler : IRequestHandler<CreateTodoGroupCommand, Guid>
    {
        private readonly ITodoGroupRepository _repository;

        public CreateTodoGroupCommandHandler(ITodoGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateTodoGroupCommand request, CancellationToken cancellationToken)
        {
            var todoGroup = new TodoGroup(request.Name);
            await _repository.AddAsync(todoGroup);
            return todoGroup.Id;
        }

    }
}
