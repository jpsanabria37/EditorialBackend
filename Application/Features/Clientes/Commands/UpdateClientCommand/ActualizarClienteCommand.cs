using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clientes.Commands.UpdateClientCommand
{
    public class ActualizarClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string NumeroDocumento { get; set; }
        public int TipoDocumentoId { get; set; }
    }

    public class ActualizarClienteCommandHandler : IRequestHandler<ActualizarClienteCommand, Response<int>>
    {
        private readonly IRepository<Cliente> _repositoryAsync;
        private readonly IRepository<TipoDocumento> _repositoryAsyncTipoDoc;
        private readonly IMapper _mapper;

        public ActualizarClienteCommandHandler(IRepository<Cliente> repositoryAsync, IMapper mapper, IRepository<TipoDocumento> repositoryAsyncTipoDoc)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _repositoryAsyncTipoDoc = repositoryAsyncTipoDoc;
        }

        public async Task<Response<int>> Handle(ActualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                throw new KeyNotFoundException("Este cliente no existe" + nameof(Cliente));
            }

            cliente.Nombre = request.Nombre;
            cliente.Apellido = request.Apellido;
            cliente.FechaNacimiento = request.FechaNacimiento;
            cliente.Telefono = request.Telefono;
            cliente.Email = request.Email;
            cliente.Direccion = request.Direccion;
            cliente.Edad = CalcularEdad(request.FechaNacimiento);
            cliente.NumeroDocumento= request.NumeroDocumento;

            // Buscar el tipo de documento correspondiente
            var tipoDocumento = await _repositoryAsyncTipoDoc.GetByIdAsync(request.TipoDocumentoId);

            if (tipoDocumento == null)
            {
                throw new KeyNotFoundException("El tipo de documento especificado no existe");
            }

            // Asignar el tipo de documento a la propiedad de navegación
            cliente.TipoDocumento = tipoDocumento;



            await _repositoryAsync.UpdateAsync(cliente);

            return new Response<int>(cliente.Id);
        }


        private int CalcularEdad(DateTime fechaNacimiento)
        {
            var edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now < fechaNacimiento.AddYears(edad))
            {
                edad--;
            }
            return edad;
        }

    }
}
