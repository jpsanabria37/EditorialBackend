using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Commands.DeleteTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Commands.UpdateTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Queries.GetAllTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Queries.GetByIdTipoDocumentoQuery;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class TipoDocumentoController  : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateTipoDocumentoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> ObtenerTipoDocumentoById(int id)
        {
            var cliente = await Mediator.Send(new GetByIdTipoDocumentoQuery { Id = id });
            var json = JsonConvert.SerializeObject(cliente);
            return Ok(json);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetAll()
        {
            var ctypes = await Mediator.Send(new GetAllTipoDocumentoQuery());
            return Ok(ctypes);
        }
        //Put api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoDocumento([FromRoute] int id, [FromBody] UpdateTipoDocumentoCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("El ID recibido en la URL no coincide con el ID del comando");
            }

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento([FromRoute] int id)
        {
            var command = new DeleteTipoDocumentoCommand { Id = id };

            return Ok(await Mediator.Send(command));
        }
    }
}
