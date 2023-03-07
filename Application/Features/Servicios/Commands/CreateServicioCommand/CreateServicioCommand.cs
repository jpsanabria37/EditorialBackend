using Application.Features.Clientes.Commands.CreateClientCommand;
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

namespace Application.Features.Servicios.Commands.CreateServicioCommand
{
    public class CreateServicioCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public double Precio { get; set; }
        public int CategoriaVehiculoId { get; set; }

    }

    public class CreateServicioCommandHandler : IRequestHandler<CreateServicioCommand, Response<int>>
    {
        
        private readonly IRepository<Servicio> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateServicioCommandHandler(IRepository<Servicio> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateServicioCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Servicio>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
    
}
