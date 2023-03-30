using Application.Exceptions;
using Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly  RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = new Response<object>();

                switch (ex)
                {
                    case ValidationException e:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.Succeeded = false;
                        response.errors = e.errors;
                        response.Message = "One or more validation errors occurred.";
                        break;
                    case KeyNotFoundException e:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        response.Succeeded = false;
                        response.Message = e.Message;
                        break;
                   case DbUpdateException e when (e.InnerException?.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547):
                        // Excepción de restricción de clave foránea (FK)
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.Succeeded = false;
                        response.Message = "No se puede borrar porque tiene asociado otras entidades";
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        response.Succeeded = false;
                        response.Message = "Internal Server Error";
                        response.Data = ex.Message; // agregar el mensaje de error al objeto de respuesta
                        break;
                }

                context.Response.ContentType = "application/json";
                var result = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(result);
            }
        }
    }
}
