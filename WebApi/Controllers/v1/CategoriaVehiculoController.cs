using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.CategoriaVehiculo.Queries.GetAllCategoriaVehiculoQuery;
using Application.Features.CategoriaVehiculo.Queries.GetByIdCategoriaVehiculoQuery;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class CategoriaVehiculoController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]

        public async Task<IActionResult> Post(CreateCategoriaVehiculoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaVehiculo>>> GetAll()
        {
            var cVehiculos = await Mediator.Send(new GetAllCategoriaVehiculoQuery());
            return Ok(cVehiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaVehiculo>> ObtenerCategoriaVehiculoPorId(int id)
        {
            var cVehiculo = await Mediator.Send(new GetByIdCategoriaVehiculoQuery { Id = id });
            return Ok(cVehiculo);
        }
    }
}
