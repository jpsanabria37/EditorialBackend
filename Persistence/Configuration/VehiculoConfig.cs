﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}