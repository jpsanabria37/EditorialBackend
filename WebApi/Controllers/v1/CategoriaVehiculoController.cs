using Application.Features.CategoriaVehiculo.Commands.CreateCategoriaVehiculoCommand;
using Application.Features.CategoriaVehiculo.Queries.GetAllCategoriaVehiculoQuery;
using Application.Features.CategoriaVehiculo.Queries.GetByIdCategoriaVehiculoQuery;
using Application.Features.Clientes.Commands.CreateClientCommand;
using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Clientes.Queries.GetByIdClient;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaVehiculo>>> GetAll()
        {
            var cVehiculos = await Mediator.Send(new GetAllCategoriaVehiculoQuery());

            var json = JsonConvert.SerializeObject(cVehiculos);

            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaVehiculo>> ObtenerClientePorId(int id)
        {
            var cVehiculo = await Mediator.Send(new GetByIdCategoriaVehiculoQuery { Id = id });
            var json = JsonConvert.SerializeObject(cVehiculo);
            return Ok(json);
        }
    }
}
