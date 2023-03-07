using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clientes.Commands.DeleteClientCommand
{
    public class EliminarClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class EliminarClienteCommandHandler : IRequestHandler<EliminarClienteCommand, Response<int>>
    {
        private readonly IRepository<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;

        public EliminarClienteCommandHandler(IRepository<Cliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryAsync.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                throw new KeyNotFoundException($"El Id {request.Id} no existe {nameof(Cliente)}");
            }

            cliente.IsDeleted = true;

            await _repositoryAsync.UpdateAsync(cliente);

            return new Response<int>(cliente.Id);
        }
    }
}
