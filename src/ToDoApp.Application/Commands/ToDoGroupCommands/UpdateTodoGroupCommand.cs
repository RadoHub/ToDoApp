using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Application.Commands.ToDoGroupCommands
{
    public class UpdateTodoGroupCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
