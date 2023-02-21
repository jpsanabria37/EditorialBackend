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

namespace Application.Features.TipoDocumentos.Commands.DeleteTipoDocumentoCommand
{
    public class DeleteTipoDocumentoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteTipoDocumentoCommandHandler : IRequestHandler<DeleteTipoDocumentoCommand, Response<int>>
    {
        private readonly IRepository<TipoDocumento> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteTipoDocumentoCommandHandler( IRepository<TipoDocumento> repositoryAsync, IMapper mapper)
        {
       
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var type = await _repositoryAsync.GetByIdAsync(request.Id);

            if (type == null)
            {
                throw new KeyNotFoundException($"El Id {request.Id} no existe {nameof(TipoDocumento)}");
            }

            type.IsDeleted = true;

            await _repositoryAsync.UpdateAsync(type);

            return new Response<int>(type.Id);
        }
    }
}


