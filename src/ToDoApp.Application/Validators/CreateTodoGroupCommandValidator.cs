using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.ToDoGroupCommands;

namespace ToDoApp.Application.Validator
{
    public class CreateTodoGroupCommandValidator : AbstractValidator<CreateTodoGroupCommand>
    {
        public CreateTodoGroupCommandValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().MaximumLength(150);
        }
    }
}
