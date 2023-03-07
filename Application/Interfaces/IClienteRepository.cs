using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> ExisteEmail(string email);

        Task<bool> NoExisteClienteConMismoTipoYNumeroDocumento(int tipoDocumentoId, string numeroDocumento);

        Task<Cliente> GetByNumeroDocumentoTipoDocumentoAsync(string numeroDocumento, int tipoDocumento);

        Task<Cliente> ObtenerPorEmail(string email);
    }
}
