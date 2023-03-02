using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Marca.Queries.GetAllMarcas
{
    public class GetAllMarcasQuery : IRequest<Response<IEnumerable<MarcaDto>>>
    {
        
    }

    public class GetAllMarcasQueryHandler : IRequestHandler<GetAllMarcasQuery, Response<IEnumerable<MarcaDto>>>
    {
        private readonly IRepository<Domain.Entities.Marca> _repository;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;
        public GetAllMarcasQueryHandler(IRepository<Domain.Entities.Marca> repository, IDistributedCache distributedCache, IMapper mapper)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<MarcaDto>>> Handle(GetAllMarcasQuery request, CancellationToken cancellationToken)
        {

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            var cacheKey = $"listadoMarcas";
            string serializedListadoMarcas;
            var listadoMarcas = new List<Domain.Entities.Marca>();
            var redisListadoMarcas = await _distributedCache.GetAsync(cacheKey);

            if (redisListadoMarcas != null)
            {
                serializedListadoMarcas = Encoding.UTF8.GetString(redisListadoMarcas);
                listadoMarcas = JsonConvert.DeserializeObject<List<Domain.Entities.Marca>>(serializedListadoMarcas);
            }
            else
            {
                var marcas = await _repository.GetAllAsync();
                listadoMarcas = marcas.ToList();
                serializedListadoMarcas = JsonConvert.SerializeObject(listadoMarcas, settings);
                redisListadoMarcas = Encoding.UTF8.GetBytes(serializedListadoMarcas);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisListadoMarcas, options);
            }

            var dtos = _mapper.Map<IEnumerable<MarcaDto>>(listadoMarcas);
            return new Response<IEnumerable<MarcaDto>>(dtos);
        }
    }
}
