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

            builder.HasQueryFilter(c => !c.IsDeleted);

        }
    }
}
