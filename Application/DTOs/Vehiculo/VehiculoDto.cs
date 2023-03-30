using Application.DTOs.Cliente;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Vehiculo
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public string NumeroPlaca { get; set; }
        public string NumeroMotor { get; set; }

        public virtual ClienteDto Cliente { get; set; }
    }
}
