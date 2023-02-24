using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clientes.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Response<int>>
    {
 
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumentoId { get; set; }

    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
    {
        private readonly IRepository<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IRepository<Cliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Cliente>(request);
            var data =  await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
