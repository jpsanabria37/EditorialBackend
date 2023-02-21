using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand
{
    public class CreateTipoDocumentoValidator : AbstractValidator<CreateTipoDocumentoCommand>
    {
        public CreateTipoDocumentoValidator()
        {
           

            RuleFor(c => c.Tipo)
               .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
               .MaximumLength(5).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Descripcion)
               .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
               .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");
        }


    }
}
