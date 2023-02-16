using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.Features.Clientes.Commands.CreateClientCommand
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        private readonly IClienteRepository _clienteRepository;
        public CreateClientCommandValidator(IClienteRepository clienteRepository)
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
               .Matches(@"^(\+57|0)[0-9]{10}$").WithMessage("{PropertyName} Debe cumplir el formato +573195029874")
               .MaximumLength(14).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Direccion)
             .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
             .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(cliente => cliente.Email)
            .NotEmpty().WithMessage("El correo electrónico es obligatorio.")
            .EmailAddress().WithMessage("El correo electrónico no es válido.")
            .MustAsync(async (email, cancellation) => !await _clienteRepository.ExisteEmail(email)).WithMessage("El correo electrónico ya está registrado en el sistema.")
            .Matches(dominiosPermitidos).WithMessage("El correo electrónico debe tener un dominio válido (gmail, outlook, yahoo, hotmail) y terminar en .com");


        }



    }
}
