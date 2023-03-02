using Domain.Common;

namespace Domain.Entities
{
    public class TipoDocumento : AuditableBaseEntity
    {

        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

    }
}
