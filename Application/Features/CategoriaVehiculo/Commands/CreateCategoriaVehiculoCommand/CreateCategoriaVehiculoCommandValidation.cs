using Application.Features.Clientes.Commands.CreateClientCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand
{
    public class CreateCategoriaVehiculoCommandValidation : AbstractValidator<CreateCategoriaVehiculoCommand>
    {
        public CreateCategoriaVehiculoCommandValidation()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");
        }
    }
}
