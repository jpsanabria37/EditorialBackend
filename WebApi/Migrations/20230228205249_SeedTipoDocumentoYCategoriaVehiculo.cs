using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipoDocumentoYCategoriaVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tipo_documentos (Tipo, Descripcion) VALUES ('CC', 'Cédula de ciudadanía') , ('CE', 'Cédula de extranjería') , ('NIT', 'Número de identificación tributario')");
            migrationBuilder.Sql("INSERT INTO categoria_vehiculos (Nombre) VALUES ('Motocicleta') , ('Automóvil') , ('Camión'), ('Camioneta')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
