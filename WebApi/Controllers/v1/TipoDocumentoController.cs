using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Clientes.Commands.DeleteClientCommand;
using Application.Features.Clientes.Commands.UpdateClientCommand;
using Application.Features.TipoDocumentos.Commands.CreateTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Commands.DeleteTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Commands.UpdateTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Queries.GetAllTipoDocumentoCommand;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TipoDocumentoController  : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateTipoDocumentoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetAll()
        {
            var ctypes = await Mediator.Send(new GetAllTipoDocumentoQuery());

            var json = JsonConvert.SerializeObject(ctypes);

            return Ok(json);
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
