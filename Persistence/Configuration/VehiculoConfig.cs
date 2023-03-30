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

            builder.Property(c => c.NumeroPlaca)
               .IsRequired()
               .HasMaxLength(20);


            builder.Property(c => c.Anio)
               .IsRequired(false)
               .HasMaxLength(40);

            builder.HasOne(p => p.Cliente) 
               .WithMany(c => c.Vehiculos) 
               .HasForeignKey(p => p.ClienteId) 
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.IsDeleted)
        .HasDefaultValue(false);

        }
    }
}
