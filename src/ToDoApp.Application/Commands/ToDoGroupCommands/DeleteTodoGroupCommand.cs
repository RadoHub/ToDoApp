using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Commands.ToDoGroupCommands
{
    public class DeleteTodoGroupCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
