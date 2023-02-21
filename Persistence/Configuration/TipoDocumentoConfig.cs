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
    public class TipoDocumentoConfig : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder)
        {
            builder.ToTable("tipo_documentos");

            builder.HasKey(c => c.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Tipo)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(80);

            builder.HasQueryFilter(c => !c.IsDeleted);


        }
    }
}
