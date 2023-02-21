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

namespace Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand
{
    public class CreateTipoDocumentoCommand : IRequest<Response<int>>
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }

    public class CreateTipoDocumentoCommandHandler : IRequestHandler<CreateTipoDocumentoCommand, Response<int>>
    {
        private readonly IRepository<TipoDocumento> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTipoDocumentoCommandHandler(IRepository<TipoDocumento> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateTipoDocumentoCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<TipoDocumento>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
