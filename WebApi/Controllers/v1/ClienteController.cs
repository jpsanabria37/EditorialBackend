using Application.DTOs;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Clientes.Commands.DeleteClientCommand;
using Application.Features.Clientes.Commands.UpdateClientCommand;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Clientes.Queries.GetByIdClient;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClienteController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll([FromQuery] GetAllClientesQueryParameters filter)
        {
            var clientes = await Mediator.Send(new GetAllClientsQuery
            {
                PageNumber= filter.PageNumber,
                PageSize= filter.PageSize,
                Nombre= filter.Nombre,
                Apellido= filter.Apellido,
            });

            var json = JsonConvert.SerializeObject(clientes);

            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObtenerClientePorId(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery { Id = id }));
        }

        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente([FromRoute] int id, [FromBody] ActualizarClienteCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID recibido en la URL no coincide con el ID del comando");
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int id)
        {
            var command = new EliminarClienteCommand { Id = id };
            
            return Ok(await Mediator.Send(command));
        }
    }
}
