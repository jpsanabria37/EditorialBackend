﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Contexts;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230307171023_ModificarServicioyEliminarMarca")]
    partial class ModificarServicioyEliminarMarca
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CategoriaVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("categoria_vehiculos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Imagen")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasDefaultValue("/images/user_default.png");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("clientes", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Precio")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("productos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaVehiculoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaVehiculoId");

                    b.ToTable("servicios", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("tipo_documentos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AnioModelo")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Kilometraje")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("vehiculos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.TipoDocumento", "TipoDocumento")
                        .WithMany("Clientes")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Entities.Servicio", b =>
                {
                    b.HasOne("Domain.Entities.CategoriaVehiculo", "CategoriaVehiculo")
                        .WithMany("Servicios")
                        .HasForeignKey("CategoriaVehiculoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CategoriaVehiculo");
                });

            modelBuilder.Entity("Domain.Entities.Vehiculo", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("Vehiculos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.CategoriaVehiculo", b =>
                {
                    b.Navigation("Servicios");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Vehiculos");
                });

            modelBuilder.Entity("Domain.Entities.TipoDocumento", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
