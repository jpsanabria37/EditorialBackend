using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.UpdateClientCommand
{
    public class UpdateClienteCommandValidator : AbstractValidator<ActualizarClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es requerido");
            RuleFor(x => x.FechaNacimiento).NotEmpty().WithMessage("La fecha de nacimiento es requerida");
            RuleFor(x => x.Telefono).NotEmpty().WithMessage("El teléfono es requerido");
            RuleFor(x => x.Email).NotEmpty().WithMessage("El email es requerido");
            RuleFor(x => x.Direccion).NotEmpty().WithMessage("La dirección es requerida");
        }
    }
}
