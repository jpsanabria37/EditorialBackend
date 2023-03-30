using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ReparacionConfig : IEntityTypeConfiguration<Reparacion>
    {
        public void Configure(EntityTypeBuilder<Reparacion> builder)
        {
            builder.ToTable("reparaciones");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.FechaInicio)
            .IsRequired();

            builder.Property(r => r.FechaFin)
       .IsRequired(false);

            builder.Property(r => r.Comentarios)
       .HasMaxLength(500)
       .IsRequired(false);

            builder.Property(r => r.Estado)
       .HasMaxLength(20)
       .IsRequired(false);
           


            builder.HasOne(p => p.Vehiculo) // la propiedad de navegación que hace referencia a la entidad Categoria
            .WithMany(c => c.Reparaciones) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
            .HasForeignKey(p => p.VehiculoId) // la clave foránea que representa la relación
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Cliente) // la propiedad de navegación que hace referencia a la entidad Categoria
           .WithMany(c => c.Reparaciones) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
           .HasForeignKey(p => p.ClienteId) // la clave foránea que representa la relación
           .IsRequired()
           .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.IsDeleted)
        .HasDefaultValue(false);

        }
    }
}
