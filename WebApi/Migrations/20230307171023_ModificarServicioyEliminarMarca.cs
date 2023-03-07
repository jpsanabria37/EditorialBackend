using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModificarServicioyEliminarMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos");

            migrationBuilder.DropTable(
                name: "marcas");

            migrationBuilder.DropIndex(
                name: "IX_vehiculos_MarcaId",
                table: "vehiculos");

            migrationBuilder.DropColumn(
                name: "MarcaId",
                table: "vehiculos");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaVehiculoId",
                table: "servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "servicios",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_servicios_CategoriaVehiculoId",
                table: "servicios",
                column: "CategoriaVehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_servicios_categoria_vehiculos_CategoriaVehiculoId",
                table: "servicios",
                column: "CategoriaVehiculoId",
                principalTable: "categoria_vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_servicios_categoria_vehiculos_CategoriaVehiculoId",
                table: "servicios");

            migrationBuilder.DropIndex(
                name: "IX_servicios_CategoriaVehiculoId",
                table: "servicios");

            migrationBuilder.DropColumn(
                name: "CategoriaVehiculoId",
                table: "servicios");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "servicios");

            migrationBuilder.AddColumn<int>(
                name: "MarcaId",
                table: "vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaVehiculoId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marcas_categoria_vehiculos_CategoriaVehiculoId",
                        column: x => x.CategoriaVehiculoId,
                        principalTable: "categoria_vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_MarcaId",
                table: "vehiculos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_marcas_CategoriaVehiculoId",
                table: "marcas",
                column: "CategoriaVehiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehiculos_marcas_MarcaId",
                table: "vehiculos",
                column: "MarcaId",
                principalTable: "marcas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
