using Application.DTOs;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Productos.Queries.GetAllProducto
{
    public class GetAllProducto : IRequest<Response<IEnumerable<Producto>>>
    {

    }

    public class GetAllProductoHandler : IRequestHandler<GetAllProducto, Response<IEnumerable<Producto>>>
    {
        private readonly IRepository<Producto> _repository;
        private readonly IMapper _mapper;

        public GetAllProductoHandler(IRepository<Producto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<Producto>>> Handle(GetAllProducto request, CancellationToken cancellationToken)
        {
            var productos = await _repository.GetAllAsync();
            

            return new Response<IEnumerable<Producto>>(productos);

        }

       
    }
}
