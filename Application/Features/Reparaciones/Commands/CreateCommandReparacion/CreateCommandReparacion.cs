using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Reparaciones.Commands.CreateCommandReparacion
{
    public class CreateCommandReparacion : IRequest<Response<int>>
    {
        public CreateCommandReparacion()
        {
            FechaInicio = DateTime.Now;
        }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Comentarios { get; set; }
        public string? Estado { get; set; }
        public decimal? CostoTotal { get; set; }
        public int VehiculoId { get; set; }
        public int ClienteId { get; set; }

    }

    public class CreateCommandReparacionHandler : IRequestHandler<CreateCommandReparacion, Response<int>>
    {
        private readonly IRepository<Reparacion> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCommandReparacionHandler(IRepository<Reparacion> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateCommandReparacion request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Reparacion>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
