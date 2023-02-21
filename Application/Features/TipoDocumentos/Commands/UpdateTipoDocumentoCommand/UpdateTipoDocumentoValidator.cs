using Application.Features.Clientes.Commands.UpdateClientCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TipoDocumentos.Commands.UpdateTipoDocumentoCommand
{
    public class UpdateTipoDocumentoValidator : AbstractValidator<UpdateTipoDocumentoCommand>

    {
        public UpdateTipoDocumentoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El id es requerido");
            RuleFor(x => x.Tipo).NotEmpty().WithMessage("El tipo del es requerido");
            RuleFor(x => x.Descripcion).NotEmpty().WithMessage("La descripcion es requerida");
        }

    }
}
