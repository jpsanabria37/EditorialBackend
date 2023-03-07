using FluentValidation;

namespace Application.Features.Vehiculo.Commands.CreateVehiculoCommand
{
    public class CreateVehiculoCommandValidator : AbstractValidator<CreateVehiculoCommand>
    {
        public CreateVehiculoCommandValidator()
        {
            RuleFor(c => c.Placa)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Color)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(20).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.Kilometraje)
                .NotEmpty().WithMessage("{PropertyName} no puede quedar vacio.")
                .MaximumLength(40).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");

            RuleFor(c => c.AnioModelo)                
                .MaximumLength(40).WithMessage("{PropertyName} no debe exceder de {MaxLength} carácteres.");
        }
    }
}
