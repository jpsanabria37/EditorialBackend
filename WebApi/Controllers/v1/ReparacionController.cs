using Application.Features.Reparaciones.Commands.CreateCommandReparacion;
using Application.Features.Reparaciones.Queries.GetAllReparaciones;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class ReparacionController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCommandReparacion command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reparacion>>> GetAll()
        {
            var reparaciones = await Mediator.Send(new GetAllReparacionesSinCache());
            return Ok(reparaciones);
        }
    }
}
