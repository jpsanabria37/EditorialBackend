using Application.DTOs.Vehiculo;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Vehiculo.Commands.CreateVehiculoCommand;
using Application.Features.Vehiculo.Commands.DeleteVehiculoCommand;
using Application.Features.Vehiculo.Commands.UpdateVehiculoCommand;
using Application.Features.Vehiculo.Queries.GetAllVehiculos;
using Application.Features.Vehiculo.Queries.GetAllVehiculosParameters;
using Application.Features.Vehiculo.Queries.GetVehiculoByIdQuery;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class VehiculoController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateVehiculoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehiculo([FromRoute] int id, [FromBody] UpdateVehiculoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID recibido en la URL no coincide con el ID del comando");
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo([FromRoute] int id)
        {
            var command = new DeleteVehiculoCommand { Id = id };
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAll()
        {
            var vehiculo = await Mediator.Send(new GetAllVehiculosSinCacheQuery());
            return Ok(vehiculo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculoById(int id)
        {
            var vehiculo = await Mediator.Send(new GetVehiculoByIdQuery { Id = id });
            return Ok(vehiculo);
        }


        [HttpGet]
        [Route("Parametros")]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAllParameter([FromQuery] VehiculoParameters filter)
        {


            var vehiculos = await Mediator.Send(new GetAllVehiculosParameters
            {
                NumeroPlaca = filter.NumeroPlaca
            });

            return Ok(vehiculos);
        }
    }
}
