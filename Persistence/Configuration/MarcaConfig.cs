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
    public class MarcaConfig : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
             builder.ToTable("marcas");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

           

          
            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasOne(p => p.CategoriaVehiculo) // la propiedad de navegación que hace referencia a la entidad Categoria
                .WithMany(c => c.Marcas) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
                .HasForeignKey(p => p.CategoriaVehiculoId) // la clave foránea que representa la relación
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
