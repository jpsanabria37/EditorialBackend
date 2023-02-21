using Application.DTOs;
using Application.Interfaces;
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

namespace Application.Features.Servicios.Queries.GetAllServicioQuery
{
    public class GetAllServicioQuery : IRequest<Response<IEnumerable<ServicioDto>>>
    {

    }
    public class GetAllServicioQueryHandler : IRequestHandler<GetAllServicioQuery, Response<IEnumerable<ServicioDto>>>
    {
        private readonly IRepository<Servicio> _repositoryAsync;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        public GetAllServicioQueryHandler(IRepository<Servicio> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }
        public async Task<Response<IEnumerable<ServicioDto>>> Handle(GetAllServicioQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"listadoServicios";
            string serializedListadoServicios;
            var listadoServicios = new List<Servicio>();
            var redisListadoServicios = await _distributedCache.GetAsync(cacheKey);

            if (redisListadoServicios != null)
            {
                serializedListadoServicios = Encoding.UTF8.GetString(redisListadoServicios);
                listadoServicios = JsonConvert.DeserializeObject<List<Servicio>>(serializedListadoServicios);
            }
            else
            {
                var cVehiculos = await _repositoryAsync.GetAllAsync();
                listadoServicios = cVehiculos.ToList();
                serializedListadoServicios = JsonConvert.SerializeObject(listadoServicios);
                redisListadoServicios = Encoding.UTF8.GetBytes(serializedListadoServicios);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisListadoServicios, options);
            }


            var dtos = _mapper.Map<IEnumerable<ServicioDto>>(listadoServicios);

            return new Response<IEnumerable<ServicioDto>>(dtos);
        }
    }
}
