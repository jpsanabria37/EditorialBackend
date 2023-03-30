using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTipoyCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tipo_documentos (Tipo, Descripcion, Created) VALUES ('CC', 'Cédula de ciudadanía', UTC_TIMESTAMP()) , ('CE', 'Cédula de extranjería', UTC_TIMESTAMP()) , ('NIT', 'Número de identificación tributario', UTC_TIMESTAMP())");
            migrationBuilder.Sql("INSERT INTO categoria_vehiculos (Nombre, Created) VALUES ('Motocicleta', UTC_TIMESTAMP()) , ('Automóvil', UTC_TIMESTAMP()) , ('Camión', UTC_TIMESTAMP()), ('Camioneta', UTC_TIMESTAMP())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
