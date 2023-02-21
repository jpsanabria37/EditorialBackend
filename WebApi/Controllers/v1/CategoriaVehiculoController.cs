using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoriaVehiculoController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateCategoriaVehiculoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
