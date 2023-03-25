using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Servicios.Queries.GetAllServicioQuery
{
    public class GetAllServicioQuerySinCache : IRequest<Response<IEnumerable<ServicioDto>>>
    {
    }

    public class GetAllServicioQuerySinCacheHandler : IRequestHandler<GetAllServicioQuerySinCache, Response<IEnumerable<ServicioDto>>>
    {
        private readonly IRepository<Servicio> _repository;
        private readonly IMapper _mapper;

        public GetAllServicioQuerySinCacheHandler(IRepository<Servicio> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<ServicioDto>>> Handle(GetAllServicioQuerySinCache request, CancellationToken cancellationToken)
        {
            var servicios = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ServicioDto>>(servicios);
            return new Response<IEnumerable<ServicioDto>>(dtos);
        }
    }
}
