using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "Kilometraje",
                table: "vehiculos");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "vehiculos",
                newName: "NumeroPlaca");

            migrationBuilder.RenameColumn(
                name: "AnioModelo",
                table: "vehiculos",
                newName: "Anio");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "vehiculos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "vehiculos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumeroMotor",
                table: "vehiculos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "NumeroMotor",
                table: "vehiculos");

            migrationBuilder.RenameColumn(
                name: "NumeroPlaca",
                table: "vehiculos",
                newName: "Placa");

            migrationBuilder.RenameColumn(
                name: "Anio",
                table: "vehiculos",
                newName: "AnioModelo");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "vehiculos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Kilometraje",
                table: "vehiculos",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
