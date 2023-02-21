using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Clientes.Commands.DeleteClientCommand;
using Application.Features.Clientes.Commands.UpdateClientCommand;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Clientes.Queries.GetByIdClient;
using Application.Features.Servicios.Commands.CreateServicioCommand;
using Application.Features.Servicios.Commands.DeleteServicioCommand;
using Application.Features.Servicios.Commands.UpdateServicioCommand;
using Application.Features.Servicios.Queries.GetAllServicioQuery;
using Application.Features.Servicios.Queries.GetByIdServicio;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ServicioController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
            var servicios = await Mediator.Send(new GetAllServicioQuery());

            var json = JsonConvert.SerializeObject(servicios);

            return Ok(json);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> ObtenerServicioPorId(int id)
        {
            var servicio = await Mediator.Send(new GetServicioByIdQuery { Id = id });
            var json = JsonConvert.SerializeObject(servicio);
            return Ok(json);
        }

        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateServicioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServicio([FromRoute] int id, [FromBody] ActualizarServicioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID recibido en la URL no coincide con el ID del comando");
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio([FromRoute] int id)
        {
            var command = new EliminarServicioCommand { Id = id };

            return Ok(await Mediator.Send(command));
        }

    }
}
