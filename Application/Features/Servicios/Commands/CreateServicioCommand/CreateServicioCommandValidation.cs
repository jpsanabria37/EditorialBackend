using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Servicios.Commands.CreateServicioCommand
{
    public class CreateServicioCommandValidation : AbstractValidator<CreateServicioCommand>
    {
        public CreateServicioCommandValidation()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");
        }
    }
}
