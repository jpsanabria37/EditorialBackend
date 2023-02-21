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

namespace Application.Features.Marca.Queries.GetByIdMarca
{
    public class GetMarcaByIdQuery : IRequest<Response<MarcaDto>>
    {
        public int Id { get; set; }
    }    
        public class GetMarcaByIdHandler : IRequestHandler<GetMarcaByIdQuery, Response<MarcaDto>>
        {

            private readonly IRepository<Domain.Entities.Marca> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetMarcaByIdHandler(IRepository<Domain.Entities.Marca> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<MarcaDto>> Handle(GetMarcaByIdQuery request, CancellationToken cancellationToken)
            {
                var marca = await _repositoryAsync.GetByIdAsync(request.Id);

                if (marca == null)
                {
                    throw new KeyNotFoundException("Esta marca no existe");
                }

                var result = _mapper.Map<MarcaDto>(marca);

                return new Response<MarcaDto>(result);

            }
        }
}

