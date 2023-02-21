using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Marca.Commands.CreateMarcaCommand
{
    public class CreateMarcaCommandValidator : AbstractValidator<CreateMarcaCommand>
    {
        public CreateMarcaCommandValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");
        }
    }
}
