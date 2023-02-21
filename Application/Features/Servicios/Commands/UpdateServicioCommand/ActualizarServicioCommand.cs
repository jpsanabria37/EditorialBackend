using Application.Features.Clientes.Commands.UpdateClientCommand;
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

namespace Application.Features.Servicios.Commands.UpdateServicioCommand
{
    public class ActualizarServicioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class ActualizarServicioCommadHandler : IRequestHandler<ActualizarServicioCommand, Response<int>>
    {
        private readonly IRepository<Servicio> _repositoryAsync;
        private readonly IMapper _mapper;

        public ActualizarServicioCommadHandler(IRepository<Servicio> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(ActualizarServicioCommand request, CancellationToken cancellationToken)
        {
            var servicio = await _repositoryAsync.GetByIdAsync(request.Id);

            if (servicio == null)
            {
                throw new KeyNotFoundException("No existe este" + nameof(Servicio));
            }

            servicio.Nombre = request.Nombre;
            servicio.Descripcion = request.Descripcion;
            

            await _repositoryAsync.UpdateAsync(servicio);

            return new Response<int>(servicio.Id);
        }
    }
}
