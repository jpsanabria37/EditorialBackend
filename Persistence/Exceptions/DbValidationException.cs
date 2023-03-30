using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Persistence.Exceptions
{
    public class DbValidationException : Exception
    {
        public DbValidationException() : base("Se han producido uno o más errores de validación.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public Dictionary<string, string[]> Errors { get; }

        public DbValidationException(DbUpdateException ex) : this()
        {
            if (ex.InnerException is SqlException sqlException && sqlException.Number == 547)
            {
                var entityName = Regex.Match(sqlException.Message, @"table\s'(?<table>.+)'\.").Groups["table"].Value;
                var constraintName = Regex.Match(sqlException.Message, @"constraint\s'(?<constraint>.+)'\.").Groups["constraint"].Value;
                var error = $"No se puede borrar el registro porque tiene registros relacionados en la tabla '{entityName}' con la restricción '{constraintName}'.";
                Errors.Add("delete", new[] { error });
            }
            else
            {
                Errors.Add("general", new[] { "Se ha producido un error de validación en la base de datos." });
            }
        }
    }
}
