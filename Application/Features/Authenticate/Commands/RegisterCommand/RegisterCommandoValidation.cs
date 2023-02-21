using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommandoValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandoValidation()
        {
            RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es requerido");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es requerido");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("El nombre de usuario es requerido")
                .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres")
                .MaximumLength(20).WithMessage("El nombre de usuario no debe tener más de 20 caracteres");

            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("La contraseña es obligatoria.")
           .MinimumLength(8).WithMessage("La contraseña debe tener al menos 8 caracteres.")
           .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula.")
           .Matches("[a-z]").WithMessage("La contraseña debe contener al menos una letra minúscula.")
           .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número.")
           .Matches("[^a-zA-Z0-9]").WithMessage("La contraseña debe contener al menos un carácter especial.");
        

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Las contraseñas no coinciden");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido")
                .EmailAddress().WithMessage("El correo electrónico no es válido");
        }
    }
}
