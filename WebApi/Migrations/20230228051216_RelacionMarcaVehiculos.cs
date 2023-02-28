using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RelacionMarcaVehiculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "VehiculoId",
                table: "marcas");

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos",
                column: "MarcaId",
                principalTable: "marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos");

            migrationBuilder.AddColumn<int>(
                name: "VehiculoId",
                table: "marcas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos",
                column: "MarcaId",
                principalTable: "marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
