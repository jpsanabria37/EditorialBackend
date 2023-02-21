using Application.Features.Clientes.Commands.DeleteClientCommand;
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

namespace Application.Features.Servicios.Commands.DeleteServicioCommand
{
    public class EliminarServicioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class EliminarServicioCommandHandler : IRequestHandler<EliminarServicioCommand, Response<int>>
    {
        private readonly IRepository<Servicio> _repositoryAsync;
        private readonly IMapper _mapper;

        public EliminarServicioCommandHandler(IRepository<Servicio> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(EliminarServicioCommand request, CancellationToken cancellationToken)
        {
            var servicio = await _repositoryAsync.GetByIdAsync(request.Id);

            if (servicio == null)
            {
                throw new KeyNotFoundException($"El Id {request.Id} no existe {nameof(Servicio)}");
            }

            servicio.IsDeleted = true;

            await _repositoryAsync.UpdateAsync(servicio);

            return new Response<int>(servicio.Id);
        }
    }
}
