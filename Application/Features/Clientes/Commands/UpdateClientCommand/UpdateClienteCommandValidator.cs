using Application.Interfaces;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.Clientes.Commands.UpdateClientCommand
{
    public class UpdateClienteCommandValidator : AbstractValidator<ActualizarClienteCommand>
    {
       
        private readonly IClienteRepository _clienteRepository;
        public UpdateClienteCommandValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;



            string dominiosPermitidos = @"^(.+)@(gmail|outlook|yahoo|hotmail)\.com$";


            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Apellido)
               .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
               .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.FechaNacimiento)
               .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.");

            RuleFor(c => c.Telefono)
               .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
               //.Matches(@"^(\+57|0)[0-9]{10}$").WithMessage("{PropertyName} Debe cumplir el formato +573195029874")
               .MaximumLength(14).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Direccion)
             .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
             .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");


            RuleFor(c => new { c.NumeroDocumento, c.TipoDocumentoId })
            .CustomAsync(async (documento, context, cancellation) =>
            {
                var clienteExistente = await _clienteRepository.GetByNumeroDocumentoTipoDocumentoAsync(documento.NumeroDocumento, documento.TipoDocumentoId);

                if (clienteExistente != null && clienteExistente.Id != context.InstanceToValidate.Id)
                {
                    context.AddFailure(nameof(Cliente.NumeroDocumento), "Ya existe un cliente con el mismo número y tipo de documento.");
                }
            });

            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
            .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de correo electrónico válida.")
            .Matches(dominiosPermitidos).WithMessage("El correo electrónico debe tener un dominio válido (gmail, outlook, yahoo, hotmail) y terminar en .com")
            .CustomAsync(async (email, context, cancellation) =>
            {
                var clienteExistente = await _clienteRepository.ObtenerPorEmail(email);

                if (clienteExistente != null && clienteExistente.Id != context.InstanceToValidate.Id)
                {
                    context.AddFailure("Ya existe un cliente con el mismo email.");
                }
            });

        }
    }
}
