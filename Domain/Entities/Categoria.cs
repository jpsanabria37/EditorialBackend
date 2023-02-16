﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categoria : AuditableBaseEntity
    {
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; } // propiedad de navegación

        // otras propiedades y métodos
    }
}
