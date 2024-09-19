using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.Commands.CreateTodoItem;

namespace ToDoApp.Application.Validator
{
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("a value must be entered").MaximumLength(200).WithMessage(x=> $"a Title must be between {x.Title.Length} characters");
            RuleFor(x=> x.Description).MaximumLength(1000);
            RuleFor(x=> x.DueDate).GreaterThan(DateTime.UtcNow);
            RuleFor(x => x.Priority).IsInEnum();
        }
    }
}
