using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("servicios");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nombre)
               .IsRequired()
               .HasMaxLength(120);

            builder.Property(c => c.Descripcion)
               .IsRequired(false)
               .HasMaxLength(120);

            builder.HasOne(p => p.CategoriaVehiculo) // la propiedad de navegación que hace referencia a la entidad Categoria
            .WithMany(c => c.Servicios) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
            .HasForeignKey(p => p.CategoriaVehiculoId) // la clave foránea que representa la relación
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.IsDeleted)
           .HasDefaultValue(false);

            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
