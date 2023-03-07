using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Vehiculo.Queries.GetVehiculoByIdQuery
{
    public class GetVehiculoByIdQuery : IRequest<Response<VehiculoDto>>
    {
        public int Id { get; set; }
    }

    public class GetVehiculoByIdHandler : IRequestHandler<GetVehiculoByIdQuery, Response<VehiculoDto>>
    {

        private readonly IRepository<Domain.Entities.Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetVehiculoByIdHandler(IRepository<Domain.Entities.Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<VehiculoDto>> Handle(GetVehiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var marca = await _repositoryAsync.GetByIdAsync(request.Id);

            if (marca == null)
            {
                throw new KeyNotFoundException("Esta marca no existe");
            }

            var result = _mapper.Map<VehiculoDto>(marca);

            return new Response<VehiculoDto>(result);

        }
    }
}
