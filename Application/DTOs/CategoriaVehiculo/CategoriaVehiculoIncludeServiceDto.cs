namespace Application.DTOs.CategoriaVehiculo
{
    public class CategoriaVehiculoIncludeServiceDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public IEnumerable<ServicioDto> Servicios { get; set; }
    }
}
