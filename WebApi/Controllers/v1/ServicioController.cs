using Application.Features.Servicios.Commands.CreateServicioCommand;
using Application.Features.Servicios.Commands.DeleteServicioCommand;
using Application.Features.Servicios.Commands.UpdateServicioCommand;
using Application.Features.Servicios.Queries.GetAllServicioQuery;
using Application.Features.Servicios.Queries.GetByIdServicio;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class ServicioController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetAll()
        {
            var servicios = await Mediator.Send(new GetAllServicioQuery());
            return Ok(servicios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> ObtenerServicioPorId(int id)
        {
            var servicio = await Mediator.Send(new GetServicioByIdQuery { Id = id });
            return Ok(servicio);
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
