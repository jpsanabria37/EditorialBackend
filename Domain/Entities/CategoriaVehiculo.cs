﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriaVehiculo : AuditableBaseEntity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Marca> Marcas { get; set; }
    }
}
