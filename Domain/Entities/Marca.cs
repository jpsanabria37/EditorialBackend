﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Marca : AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public int CategoriaVehiculoId { get; set; }

        public CategoriaVehiculo CategoriaVehiculo { get; set; }
    }
}