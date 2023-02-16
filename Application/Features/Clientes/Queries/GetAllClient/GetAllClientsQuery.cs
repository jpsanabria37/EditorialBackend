using Application.DTOs;
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
            var cacheKey = $"listadoClientes_{request.PageNumber}_{request.PageSize}_{request.Apellido}_{request.Nombre}";
            string serializedListadoClientes;
            var listadoClientes = new List<Cliente>();
            var redisListadoClientes = await _distributedCache.GetAsync(cacheKey);
            
            if(redisListadoClientes != null)
            {
                serializedListadoClientes = Encoding.UTF8.GetString(redisListadoClientes);
                listadoClientes = JsonConvert.DeserializeObject<List<Cliente>>(serializedListadoClientes);
            }
            else
            {
                listadoClientes = await _repository.ListAsync(new PagedClientesSpecification(request));
                serializedListadoClientes = JsonConvert.SerializeObject(listadoClientes);
                redisListadoClientes = Encoding.UTF8.GetBytes(serializedListadoClientes);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisListadoClientes ,options);
            }


            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(listadoClientes);

            return new PageResponse<IEnumerable<ClienteDto>>(dtos, request.PageNumber, request.PageSize);
           
        }
    }
}
