using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Vehiculo.Commands.DeleteVehiculoCommand
{
    public class DeleteVehiculoCommand : IRequest<Response<int>>
    {        public int Id { get; set; }
    }

    public class DeleteVehiculoCommandHandler : IRequestHandler<DeleteVehiculoCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Vehiculo> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteVehiculoCommandHandler(IRepository<Domain.Entities.Vehiculo> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteVehiculoCommand request, CancellationToken cancellationToken)
        {
            var vehiculo = await _repositoryAsync.GetByIdAsync(request.Id);

            if (vehiculo == null)
            {
                throw new KeyNotFoundException($"El Id {request.Id} no existe {nameof(Domain.Entities.Vehiculo)}");
            }


            await _repositoryAsync.DeleteAsync(vehiculo);

            return new Response<int>("melo");
        }
    }
}
