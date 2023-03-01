﻿using Application.Features.Clientes.Queries.GetAllClient;
using Ardalis.Specification;
using Domain.Entities;


namespace Application.Specifications
{
    public class PagedClientesSpecification : Specification<Cliente>
    {
        public PagedClientesSpecification(GetAllClientsQuery filter)
        {
            Query.Include(x => x.TipoDocumento);
            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if(!string.IsNullOrEmpty(filter.Nombre))
                Query.Search(x => x.Nombre, $"%{filter.Nombre}%");

            if (!string.IsNullOrEmpty(filter.Apellido))
                Query.Search(x => x.Apellido, $"%{filter.Apellido}%");

            
        }
    }
}
