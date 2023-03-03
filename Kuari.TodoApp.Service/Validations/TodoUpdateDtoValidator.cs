using FluentValidation;
using Kuari.TodoApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Service.Validations
{
    public class TodoUpdateDtoValidator : AbstractValidator<TodoUpdateDto>
    {
        public TodoUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} girilmesi zorunlu alandır.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("{PropertyName} girilmesi zorunlu alandır");
            RuleFor(x => x.IsCompleted).NotNull().WithMessage("{PropertyName} tanımlanması zorunlu alandır.");
         
        }
    }
}
