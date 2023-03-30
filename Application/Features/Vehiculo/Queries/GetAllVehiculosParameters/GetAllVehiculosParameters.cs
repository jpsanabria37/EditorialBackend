using Application.DTOs;
using Application.DTOs.Vehiculo;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehiculo.Queries.GetAllVehiculosParameters
{
    public class GetAllVehiculosParameters : IRequest<Response<IEnumerable<VehiculoIncludeClienteDto>>>
    {
        public string NumeroPlaca { get; set; }
    }

    public class GetAllVehiculosParametersHandler : IRequestHandler<GetAllVehiculosParameters, Response<IEnumerable<VehiculoIncludeClienteDto>>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Vehiculo> _repository;
        private readonly IMapper _mapper;

        public GetAllVehiculosParametersHandler(IRepositoryAsync<Domain.Entities.Vehiculo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<VehiculoIncludeClienteDto>>> Handle(GetAllVehiculosParameters request, CancellationToken cancellationToken)
        {
            var vehiculos = await _repository.ListAsync(new PagedVehiculoSpecification(request));
            var dtos = _mapper.Map<IEnumerable<VehiculoIncludeClienteDto>>(vehiculos);
            return new Response<IEnumerable<VehiculoIncludeClienteDto>>(dtos);
        }
    }
}
