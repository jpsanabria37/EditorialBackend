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
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("productos");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Descripcion)
               .IsRequired()
               .HasMaxLength(120);

            builder.Property(p => p.Precio)
                .IsRequired()
                .HasPrecision(9, 2)
                .HasColumnType("decimal(9,2)")
                .HasDefaultValue(0.0);

            builder.HasQueryFilter(c => !c.IsDeleted);

            builder.HasOne(p => p.Categoria) // la propiedad de navegación que hace referencia a la entidad Categoria
                .WithMany(c => c.Productos) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
                .HasForeignKey(p => p.CategoriaId) // la clave foránea que representa la relación
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
