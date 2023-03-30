using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Vehiculo.Queries.GetAllVehiculosParameters;
using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    public class PagedVehiculoSpecification : Specification<Vehiculo>
    {
        public PagedVehiculoSpecification(GetAllVehiculosParameters filter)
        {
            Query.Include(x => x.Cliente)
          .ThenInclude(c => c.TipoDocumento);
            if (!string.IsNullOrEmpty(filter.NumeroPlaca))
                Query.Search(x => x.NumeroPlaca, $"%{filter.NumeroPlaca}%");
        }
    }
}
