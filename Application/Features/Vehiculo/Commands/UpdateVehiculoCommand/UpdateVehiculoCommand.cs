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

namespace Application.Features.Vehiculo.Commands.UpdateVehiculoCommand
{
    public class UpdateVehiculoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Kilometraje { get; set; }
        public string AnioModelo { get; set; }
    }

    public class UpdateVehiculoCommandHandler : IRequestHandler<UpdateVehiculoCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateVehiculoCommandHandler(IRepository<Domain.Entities.Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repositoryAsync.GetByIdAsync(request.Id);

            if (vehiculo == null)
            {
                throw new KeyNotFoundException("Este cliente no existe" + nameof(Domain.Entities.Vehiculo));
            }

            vehiculo.Placa = request.Placa;
            vehiculo.Color = request.Color;
            vehiculo.Kilometraje = request.Kilometraje;
            vehiculo.AnioModelo = request.AnioModelo;
            

            await _repositoryAsync.UpdateAsync(vehiculo);

            return new Response<int>(vehiculo.Id);
        }
    }
}
