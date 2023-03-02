using Application.DTOs;
using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.DeleteClientCommand;
using Application.Features.Clientes.Commands.UpdateClientCommand;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Clientes.Queries.GetByIdClient;
using Application.Features.Marca.Commands.CreateMarcaCommand;
using Application.Features.Marca.Commands.DeleteMarcaCommand;
using Application.Features.Marca.Commands.UpdateMarcaCommand;
using Application.Features.Marca.Queries.GetAllMarcas;
using Application.Features.Marca.Queries.GetByIdMarca;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class MarcaController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateMarcaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca([FromRoute] int id, [FromBody] UpdateMarcaCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest("El ID recibido en la URL no coincide con el ID del comando");
            }

            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca([FromRoute] int id)
        {
            var command = new DeleteMarcaCommand { Id = id };
            return Ok(await Mediator.Send(command));
        }

        //GET api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDto>>> GetAll()
        {
            var marcas = await Mediator.Send(new GetAllMarcasQuery());
            return Ok(marcas);
        }

        //GET api/<controller>/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<MarcaDto>> GetMarcaById(int id)
        {
            var marca = await Mediator.Send(new GetMarcaByIdQuery { Id = id });
            return Ok(marca);
        }
    }
}
