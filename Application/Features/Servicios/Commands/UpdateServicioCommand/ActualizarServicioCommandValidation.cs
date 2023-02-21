using Application.Features.Clientes.Commands.UpdateClientCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Servicios.Commands.UpdateServicioCommand
{
    public class ActualizarServicioCommandValidation : AbstractValidator<ActualizarServicioCommand>
    {
        public ActualizarServicioCommandValidation()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            
        }
    }
}
