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

namespace Application.Features.Marca.Commands.DeleteMarcaCommand
{
    public class DeleteMarcaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteMarcaCommandHandler : IRequestHandler<DeleteMarcaCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Marca> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteMarcaCommandHandler(IRepository<Domain.Entities.Marca> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteMarcaCommand request, CancellationToken cancellationToken)
        {
            var marca = await _repositoryAsync.GetByIdAsync(request.Id);

            if (marca == null)
            {
                throw new KeyNotFoundException($"El Id {request.Id} no existe {nameof(Cliente)}");
            }

            marca.IsDeleted = true;

            await _repositoryAsync.UpdateAsync(marca);

            return new Response<int>(marca.Id);
        }
    }
}
