using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Marca.Commands.UpdateMarcaCommand
{
    public class UpdateMarcaCommandValidator : AbstractValidator<UpdateMarcaCommand>
    {
        public UpdateMarcaCommandValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.Id).NotEmpty().WithMessage("El Id es requerido");
            RuleFor(x => x.CategoriaVehiculoId).NotEmpty().WithMessage("El CategoriaVehicleId es requerido");
        }
    }
}
