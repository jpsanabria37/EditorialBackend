using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class VehiculoConfig : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("vehiculos");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Placa)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(c => c.Color)
               .IsRequired()
               .HasMaxLength(20);

            builder.Property(c => c.AnioModelo)
               .IsRequired(false)
               .HasMaxLength(40);

            builder.Property(c => c.Kilometraje)
               .IsRequired()
               .HasMaxLength(40);

            builder.HasOne(p => p.Cliente) // la propiedad de navegación que hace referencia a la entidad Categoria
               .WithMany(c => c.Vehiculos) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
               .HasForeignKey(p => p.ClienteId) // la clave foránea que representa la relación
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);


            builder.Property(c => c.IsDeleted)
           .HasDefaultValue(false);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
