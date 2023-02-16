using Application.DTOs;
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

namespace Application.Features.Clientes.Queries.GetByIdClient
{
    public class GetClientByIdQuery : IRequest<Response<ClienteDto>>
    {
        public int Id { get; set; }
    }
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Response<ClienteDto>>
    {

        private readonly IRepository<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetClientByIdHandler(IRepository<Cliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<ClienteDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Este cliente no existe");
            }

            var result = _mapper.Map<ClienteDto>(cliente);

            return new Response<ClienteDto>(result);

        }
    }
}
