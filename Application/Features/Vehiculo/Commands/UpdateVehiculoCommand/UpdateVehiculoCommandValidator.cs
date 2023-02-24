using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehiculo.Commands.UpdateVehiculoCommand
{
    public class UpdateVehiculoCommandValidator : AbstractValidator<UpdateVehiculoCommand>
    {
        public UpdateVehiculoCommandValidator()
        {
            RuleFor(x => x.Placa).NotEmpty().WithMessage("La placa es requerida");
            RuleFor(x => x.Color).NotEmpty().WithMessage("El color es requerido");
            RuleFor(x => x.Kilometraje).NotEmpty().WithMessage("El Kilometraje es requerido");
        }
    }
}
