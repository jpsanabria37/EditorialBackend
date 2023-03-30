﻿namespace Application.DTOs.Cliente
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        public string NumeroDocumento { get; set; }
        public int Edad { get; set; }
        public TipoDocumentoDto TipoDocumento { get; set; }

    }
}
