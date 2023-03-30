﻿using Application.DTOs.CategoriaVehiculo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ServicioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }
        public CategoriaVehiculoDto CategoriaVehiculo { get; set; }
    }
}
