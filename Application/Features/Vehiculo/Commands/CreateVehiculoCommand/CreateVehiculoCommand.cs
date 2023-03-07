using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Features.Vehiculo.Commands.CreateVehiculoCommand
{
    public class CreateVehiculoCommand : IRequest<Response<int>>
    {
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Kilometraje { get; set; }
        public string AnioModelo { get; set; }
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
