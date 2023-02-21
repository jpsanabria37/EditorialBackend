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

namespace Application.Features.Servicios.Queries.GetByIdServicio
{
    public class GetServicioByIdQuery : IRequest<Response<ServicioDto>>
    {
        public int Id { get; set; }
    }

    public class GetServicioByIdQueryHandler : IRequestHandler<GetServicioByIdQuery, Response<ServicioDto>>
    {
        private readonly IRepository<Servicio> _repositoryAsync;
        private readonly IMapper _mapper;
        public GetServicioByIdQueryHandler(IRepository<Servicio> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<ServicioDto>> Handle(GetServicioByIdQuery request, CancellationToken cancellationToken)
        {
            var servicios = await _repositoryAsync.GetByIdAsync(request.Id);

            if (servicios == null)
            {
                throw new KeyNotFoundException("Este servicio no existe");
            }

            var result = _mapper.Map<ServicioDto>(servicios);

            return new Response<ServicioDto>(result);
        }
    }
}
