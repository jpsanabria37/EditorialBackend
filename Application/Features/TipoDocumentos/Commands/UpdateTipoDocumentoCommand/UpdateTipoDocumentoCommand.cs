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

namespace Application.Features.TipoDocumentos.Commands.UpdateTipoDocumentoCommand
{
    public class UpdateTipoDocumentoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }

    public class UpdateTipoDocumentoCommandHandler : IRequestHandler<UpdateTipoDocumentoCommand, Response<int>>
    {
        private readonly IRepository<TipoDocumento> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateTipoDocumentoCommandHandler(IRepository<TipoDocumento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var type = await _repositoryAsync.GetByIdAsync(request.Id);

            if (type == null)
            {
                throw new KeyNotFoundException("Este cliente no existe" + nameof(TipoDocumento));
            }

            type.Tipo = request.Tipo;
            type.Descripcion = request.Descripcion;

            await _repositoryAsync.UpdateAsync(type);

            return new Response<int>(type.Id);

        }

    }
}
