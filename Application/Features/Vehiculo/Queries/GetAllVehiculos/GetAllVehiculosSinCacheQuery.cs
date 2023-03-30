using Application.DTOs.Vehiculo;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Vehiculo.Queries.GetAllVehiculos
{
    public class GetAllVehiculosSinCacheQuery : IRequest<Response<IEnumerable<VehiculoDto>>>
    {
    }

    public class GetAllVehiculosSinCacheQueryHandler : IRequestHandler<GetAllVehiculosSinCacheQuery, Response<IEnumerable<VehiculoDto>>>
    {
        private readonly IRepository<Domain.Entities.Vehiculo> _repository;
        private readonly IMapper _mapper;

        public GetAllVehiculosSinCacheQueryHandler(IRepository<Domain.Entities.Vehiculo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<Response<IEnumerable<VehiculoDto>>> Handle(GetAllVehiculosSinCacheQuery request, CancellationToken cancellationToken)
        {
            var vehiculos = await _repository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<VehiculoDto>>(vehiculos);
            return new Response<IEnumerable<VehiculoDto>>(dtos);
        }
    }
}
