using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Application.Features.CategoriaVehiculo.Queries.GetAllCategoriaVehiculoQuery
{
    public class GetAllCategoriaVehiculoQueryCache : IRequest<Response<IEnumerable<CategoriaVehiculoDto>>>
    {

    }

    public class GetAllCategoriaVehiculoQueryHandler : IRequestHandler<GetAllCategoriaVehiculoQueryCache, Response<IEnumerable<CategoriaVehiculoDto>>>
    {
        private readonly IRepository<Domain.Entities.CategoriaVehiculo> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetAllCategoriaVehiculoQueryHandler(IRepository<Domain.Entities.CategoriaVehiculo> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }



        public async Task<Response<IEnumerable<CategoriaVehiculoDto>>> Handle(GetAllCategoriaVehiculoQueryCache request, CancellationToken cancellationToken)
        {

           /* var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };*/
           // var cacheKey = $"listadoCategoriaVehiculos";
          //  string serializedListadoCVehiculos;
            var listadoCVehiculos = new List<Domain.Entities.CategoriaVehiculo>();
            // var redisListadoCVehiculos = await _distributedCache.GetAsync(cacheKey);

            /* if (redisListadoCVehiculos != null)
             {
                 serializedListadoCVehiculos = Encoding.UTF8.GetString(redisListadoCVehiculos);
                 listadoCVehiculos = JsonConvert.DeserializeObject<List<Domain.Entities.CategoriaVehiculo>>(serializedListadoCVehiculos);
             }
             else
             {
                 var cVehiculos = await _repositoryAsync.GetAllAsync();
                 listadoCVehiculos = cVehiculos.ToList();
                 serializedListadoCVehiculos = JsonConvert.SerializeObject(listadoCVehiculos, settings);
                 redisListadoCVehiculos = Encoding.UTF8.GetBytes(serializedListadoCVehiculos);

                 var options = new DistributedCacheEntryOptions()
                     .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                     .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                 await _distributedCache.SetAsync(cacheKey, redisListadoCVehiculos, options);
             }*/

            var cVehiculos = await _repositoryAsync.GetAllAsync();
            listadoCVehiculos = cVehiculos.ToList();
            var dtos = _mapper.Map<IEnumerable<CategoriaVehiculoDto>>(listadoCVehiculos);

            return new Response<IEnumerable<CategoriaVehiculoDto>>(dtos);
        }
    }
}
