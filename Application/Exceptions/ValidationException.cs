using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Se han producido uno o mas errores de validación")
        {
            errors = new Dictionary<string, string[]>();
        }

        public Dictionary<string, string[]> errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var propertyNames = failures.Select(e => e.PropertyName).Distinct();
            foreach (var propertyName in propertyNames)
            {
                var errorMessages = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();
                errors.Add(propertyName, errorMessages);
            }
        }
    }
}
