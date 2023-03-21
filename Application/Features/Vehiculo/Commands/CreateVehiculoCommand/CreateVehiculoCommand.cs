using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Vehiculo.Commands.CreateVehiculoCommand
{
    public class CreateVehiculoCommand : IRequest<Response<int>>
    {
            public int ClienteId { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Anio { get; set; }
            public string NumeroPlaca { get; set; }
            public string NumeroMotor { get; set; }
    }

    public class CreateVehiculoCommandHandler : IRequestHandler<CreateVehiculoCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateVehiculoCommandHandler(IRepository<Domain.Entities.Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Domain.Entities.Vehiculo>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
