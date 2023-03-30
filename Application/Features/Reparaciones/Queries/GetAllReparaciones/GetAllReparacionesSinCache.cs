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

namespace Application.Features.Reparaciones.Queries.GetAllReparaciones
{
    public class GetAllReparacionesSinCache : IRequest<Response<IEnumerable<Reparacion>>>
    {
    }

    public class GetAllReparacionesSinCacheHandler : IRequestHandler<GetAllReparacionesSinCache, Response<IEnumerable<Reparacion>>>
    {

        private readonly IRepository<Reparacion> _repository;
        private readonly IMapper _mapper;

        public GetAllReparacionesSinCacheHandler(IRepository<Reparacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<Reparacion>>> Handle(GetAllReparacionesSinCache request, CancellationToken cancellationToken)
        {
            var reparaciones = await _repository.GetAllAsync();
            //var dtos = _mapper.Map<IEnumerable<ServicioDto>>(servicios);
            return new Response<IEnumerable<Reparacion>>(reparaciones);
        }
    }
}
