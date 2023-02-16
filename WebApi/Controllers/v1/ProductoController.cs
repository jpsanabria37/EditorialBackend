using Application.Features.Clientes.Queries.GetAllClient;
using Application.Features.Productos.Queries.GetAllProducto;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductoController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var productos = await Mediator.Send(new GetAllProducto());
            var json = JsonConvert.SerializeObject(productos, serializerSettings);
            return Ok(json);
        }
    }
}
