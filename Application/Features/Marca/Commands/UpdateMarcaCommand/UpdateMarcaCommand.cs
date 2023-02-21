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

namespace Application.Features.Marca.Commands.UpdateMarcaCommand
{
    public class UpdateMarcaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaVehiculoId { get; set; }
    }

    public class UpdateMarcaCommandHandler : IRequestHandler<UpdateMarcaCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Marca> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateMarcaCommandHandler(IRepository<Domain.Entities.Marca> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _repositoryAsync.GetByIdAsync(request.Id);

            if (marca == null)
            {
                throw new KeyNotFoundException("Esta marca no existe" + nameof(Domain.Entities.Marca));
            }

            marca.Nombre = request.Nombre;
            marca.CategoriaVehiculoId = request.CategoriaVehiculoId;


            await _repositoryAsync.UpdateAsync(marca);

            return new Response<int>(marca.Id);
        }
    }
}
