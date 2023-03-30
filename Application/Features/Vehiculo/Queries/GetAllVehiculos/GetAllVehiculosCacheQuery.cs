using Application.DTOs.Vehiculo;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Application.Features.Vehiculo.Queries.GetAllVehiculos
{
    public class GetAllVehiculosCacheQuery : IRequest<Response<IEnumerable<VehiculoDto>>>
    {

    }

    public class GetAllVehiculosQueryHandler : IRequestHandler<GetAllVehiculosCacheQuery, Response<IEnumerable<VehiculoDto>>>
    {
        private readonly IRepository<Domain.Entities.Vehiculo> _repository;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;
        public GetAllVehiculosQueryHandler(IRepository<Domain.Entities.Vehiculo> repository, IDistributedCache distributedCache, IMapper mapper)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<VehiculoDto>>> Handle(GetAllVehiculosCacheQuery request, CancellationToken cancellationToken)
        {
           /* var cacheKey = $"listadoVehiculos";
            string serializedListadoVehiculos;*/
            var listadoVehiculos = new List<Domain.Entities.Vehiculo>();
            /*var redisListadoVehiculos = await _distributedCache.GetAsync(cacheKey);

            if (redisListadoVehiculos != null)
            {
                serializedListadoVehiculos = Encoding.UTF8.GetString(redisListadoVehiculos);
                listadoVehiculos = JsonConvert.DeserializeObject<List<Domain.Entities.Vehiculo>>(serializedListadoVehiculos);
            }
            else
            {
                var vehiculos = await _repository.GetAllAsync();
                listadoVehiculos = vehiculos.ToList();
                serializedListadoVehiculos = JsonConvert.SerializeObject(listadoVehiculos);
                redisListadoVehiculos = Encoding.UTF8.GetBytes(serializedListadoVehiculos);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisListadoVehiculos, options);
            }
            */

            var vehiculos = await _repository.GetAllAsync();
            listadoVehiculos = vehiculos.ToList();
            var dtos = _mapper.Map<IEnumerable<VehiculoDto>>(listadoVehiculos);
            return new Response<IEnumerable<VehiculoDto>>(dtos);
        }
    }
}
