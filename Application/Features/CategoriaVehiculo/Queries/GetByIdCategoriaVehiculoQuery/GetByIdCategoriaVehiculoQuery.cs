using Application.DTOs;
using Application.Features.Clientes.Queries.GetByIdClient;
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

namespace Application.Features.CategoriaVehiculo.Queries.GetByIdCategoriaVehiculoQuery
{
    public class GetByIdCategoriaVehiculoQuery : IRequest<Response<CategoriaVehiculoDto>>
    {
        public int Id { get; set; }
    }

    public class GetByIdCategoriaVehiculoQueryHandler : IRequestHandler<GetByIdCategoriaVehiculoQuery, Response<CategoriaVehiculoDto>>
    {
        private readonly IRepository<Domain.Entities.CategoriaVehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdCategoriaVehiculoQueryHandler(IRepository<Domain.Entities.CategoriaVehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<CategoriaVehiculoDto>> Handle(GetByIdCategoriaVehiculoQuery request, CancellationToken cancellationToken)
        {
            var cVehiculo  = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cVehiculo == null)
            {
                throw new KeyNotFoundException("Esta categoría de vehículo no existe");
            }

            var result = _mapper.Map<CategoriaVehiculoDto>(cVehiculo);

            return new Response<CategoriaVehiculoDto>(result);

        }
    }
}
