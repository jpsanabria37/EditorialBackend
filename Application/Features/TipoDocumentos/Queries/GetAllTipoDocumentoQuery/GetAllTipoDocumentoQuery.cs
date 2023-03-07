using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Application.Features.TipoDocumentos.Queries.GetAllTipoDocumentoCommand
{
    public class GetAllTipoDocumentoQuery : IRequest<Response<IEnumerable<TipoDocumentoDto>>>
    {


    }

    public class GetAllTipoDocumentoCommandHandler : IRequestHandler<GetAllTipoDocumentoQuery, Response<IEnumerable<TipoDocumentoDto>>>
    {

        private readonly IRepository<TipoDocumento> _repository;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public GetAllTipoDocumentoCommandHandler(IRepository<TipoDocumento> repository, IDistributedCache distributedCache, IMapper mapper)
        {
            _repository = repository;
            _distributedCache = distributedCache;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TipoDocumentoDto>>> Handle(GetAllTipoDocumentoQuery request, CancellationToken cancellationToken)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            var cacheKey = $"listadoTipoDocumentos";
                string serializedListadoTipoDocumentos;
                var listadoTipoDocumentos = new List<TipoDocumento>();
                var redisListadoTipoDocumentos = await _distributedCache.GetAsync(cacheKey);

                if (redisListadoTipoDocumentos != null)
                {
                    serializedListadoTipoDocumentos = Encoding.UTF8.GetString(redisListadoTipoDocumentos);
                    listadoTipoDocumentos = JsonConvert.DeserializeObject<List<TipoDocumento>>(serializedListadoTipoDocumentos);
                }
                else
                {
                    var tipo = await _repository.GetAllAsync();
                    listadoTipoDocumentos = tipo.ToList();
                    serializedListadoTipoDocumentos = JsonConvert.SerializeObject(listadoTipoDocumentos, settings);
                    redisListadoTipoDocumentos = Encoding.UTF8.GetBytes(serializedListadoTipoDocumentos);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distributedCache.SetAsync(cacheKey, redisListadoTipoDocumentos, options);
                }

                var dtos = _mapper.Map<IEnumerable<TipoDocumentoDto>>(listadoTipoDocumentos);
                return new Response<IEnumerable<TipoDocumentoDto>>(dtos);
            
        }
    }
}
