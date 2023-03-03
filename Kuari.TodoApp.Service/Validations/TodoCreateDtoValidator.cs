using FluentValidation;
using Kuari.TodoApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuari.TodoApp.Service.Validations
{
    public class TodoCreateDtoValidator : AbstractValidator<TodoCreateDto>
    {
        public TodoCreateDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content alanı boş olamaz");
            RuleFor(x => x.IsCompleted).NotEmpty().WithMessage("İş Durumunu belirtiniz");
        }
    }
}
