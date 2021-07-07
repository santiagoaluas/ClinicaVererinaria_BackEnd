using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class RazaConfig : IEntityTypeConfiguration<Raza>
    {
        public void Configure(EntityTypeBuilder<Raza> entity)
        { 
                entity.HasKey(e => e.IdRaza)
                    .HasName("PRIMARY");

                entity.ToTable("raza");

                entity.Property(e => e.IdRaza)
                    .HasMaxLength(36)
                    .HasColumnName("idRaza");

                entity.Property(e => e.DescripcionRaza)
                    .HasMaxLength(255)
                    .HasColumnName("descripcionRaza");

                entity.Property(e => e.NombreRaza)
                    .HasMaxLength(45)
                    .HasColumnName("nombreRaza");
        }
    }
}
