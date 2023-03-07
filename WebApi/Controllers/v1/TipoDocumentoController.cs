using Application.Features.TipoDocumentos.Queries.GetAllTipoDocumentoCommand;
using Application.Features.TipoDocumentos.Queries.GetByIdTipoDocumentoQuery;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.v1
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    public class TipoDocumentoController  : BaseApiController
    {


        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> ObtenerTipoDocumentoById(int id)
        {
            var tDoc = await Mediator.Send(new GetByIdTipoDocumentoQuery { Id = id });
           
            return Ok(tDoc);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetAll()
        {
            var ctypes = await Mediator.Send(new GetAllTipoDocumentoQuery());
            return Ok(ctypes);
        }
 
    }
}
