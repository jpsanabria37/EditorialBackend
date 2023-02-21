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

namespace Application.Features.Marca.Commands.CreateMarcaCommand
{
    public class CreateMarcaCommand : IRequest<Response<int>>
    {
        public string Nombre { get; set; }
        public int CategoriaVehiculoId { get; set; }


    }
    public class CreateMarcaCommandHandler : IRequestHandler<CreateMarcaCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Marca> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateMarcaCommandHandler(IRepository<Domain.Entities.Marca> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMarcaCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Domain.Entities.Marca>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);
            return new Response<int>(data.Id);
        }
    }
}
