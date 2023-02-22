using Application.DTOs;
using Application.DTOs.TipoDocumentos;
using Application.Features.Clientes.Queries.GetByIdClient;
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

namespace Application.Features.TipoDocumentos.Queries.GetByIdTipoDocumentoQuery
{
    public class GetByIdTipoDocumentoQuery : IRequest<Response<TipoDocumentoDto>>
    {
        public int Id { get; set; }
    }

    public class GetByIdTipoDocumentoQueryHandler : IRequestHandler<GetByIdTipoDocumentoQuery, Response<TipoDocumentoDto>>
    {
        private readonly IRepository<TipoDocumento> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdTipoDocumentoQueryHandler(IRepository<TipoDocumento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<TipoDocumentoDto>> Handle(GetByIdTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var type = await _repositoryAsync.GetByIdAsync(request.Id);

            if (type == null)
            {
                throw new KeyNotFoundException("Este tipo documento no existe");
            }

            var result = _mapper.Map<TipoDocumentoDto>(type);

            return new Response<TipoDocumentoDto>(result);
        }
    }
}
