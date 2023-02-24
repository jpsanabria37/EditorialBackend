using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.Apellido)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.FechaNacimiento)
               .IsRequired();

            builder.Property(c => c.Telefono)
               .IsRequired()
               .HasMaxLength(14);

            builder.Property(c => c.Email)
               .HasMaxLength(100);

            builder.Property(c => c.Direccion)
               .IsRequired()
               .HasMaxLength(120);

            builder.Property(c => c.Edad);

            builder.Property(c => c.CreatedBy)
                .HasMaxLength(30);

            builder.Property(c => c.NumeroDocumento)
              .HasMaxLength(40);

            builder.Property(c => c.LastModifiedBy)
               .HasMaxLength(30);
          
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Imagen)
            .HasMaxLength(1000) // Establece la longitud máxima de la ruta de la imagen a 1000 caracteres
            .IsRequired(false) // La imagen es requerida
            .HasDefaultValue("/images/user_default.png");

            builder.HasOne(p => p.TipoDocumento) // la propiedad de navegación que hace referencia a la entidad Categoria
                .WithMany(c => c.Clientes) // la propiedad de navegación de la entidad Categoria que representa la relación inversa
                .HasForeignKey(p => p.TipoDocumentoId) // la clave foránea que representa la relación
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
