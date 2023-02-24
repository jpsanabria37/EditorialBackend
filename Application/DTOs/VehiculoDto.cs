using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string AnioModelo { get; set; }
        public string Kilometraje { get; set; }
    }
}
