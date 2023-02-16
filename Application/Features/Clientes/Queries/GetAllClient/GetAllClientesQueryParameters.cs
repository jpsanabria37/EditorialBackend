using Application.DTOs;
using Application.Parameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetAllClient
{
    public class GetAllClientesQueryParameters : RequestParameters
    {
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }
}
