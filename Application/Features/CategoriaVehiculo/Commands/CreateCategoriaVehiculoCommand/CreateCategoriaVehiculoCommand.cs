using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand
{
    public class CreateCategoriaVehiculoCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

    public class CreateCategoriaVehiculoCommandHandler : IRequestHandler<CreateCategoriaVehiculoCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.CategoriaVehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateCategoriaVehiculoCommandHandler(IRepository<Domain.Entities.CategoriaVehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoriaVehiculoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Domain.Entities.CategoriaVehiculo>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
