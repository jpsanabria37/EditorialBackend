using Application.DTOs.Cliente;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Application.Features.Clientes.Queries.GetAllClient
{
    public class GetAllClientsQuery : IRequest<PageResponse<IEnumerable<ClienteDto>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }

    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PageResponse<IEnumerable<ClienteDto>>>
    {
        private readonly IRepositoryAsync<Cliente> _repository;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IRepositoryAsync<Cliente> repository, IMapper mapper, IDistributedCache distributedCache = null)
        {
            _repository = repository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<PageResponse<IEnumerable<ClienteDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

            List<Cliente> listadoClientes = null;
            string cacheKey = null;
            byte[] redisListadoClientes = null;



            if (!string.IsNullOrEmpty(request.Apellido) || !string.IsNullOrEmpty(request.Nombre))
            {
                cacheKey = $"listadoClientes_{request.PageNumber}_{request.PageSize}_{request.Apellido}_{request.Nombre}";
                var redisListadoClientesCached = await _distributedCache.GetAsync(cacheKey);
                if (redisListadoClientesCached != null)
                {
                    redisListadoClientes = redisListadoClientesCached;
                    var serializedListadoClientesCache = Encoding.UTF8.GetString(redisListadoClientes);
                    listadoClientes = JsonConvert.DeserializeObject<List<Cliente>>(serializedListadoClientesCache);
                    var dtosCache = _mapper.Map<IEnumerable<ClienteDto>>(listadoClientes);
                    return new PageResponse<IEnumerable<ClienteDto>>(dtosCache, request.PageNumber, request.PageSize);
                }
            }

            listadoClientes = await _repository.ListAsync(new PagedClientesSpecification(request));
            var serializedListadoClientes = JsonConvert.SerializeObject(listadoClientes, settings);
            redisListadoClientes = Encoding.UTF8.GetBytes(serializedListadoClientes);

            if (!string.IsNullOrEmpty(cacheKey))
            {
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _distributedCache.SetAsync(cacheKey, redisListadoClientes, options);
            }

            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(listadoClientes);
            return new PageResponse<IEnumerable<ClienteDto>>(dtos, request.PageNumber, request.PageSize);

        }
    }
}
