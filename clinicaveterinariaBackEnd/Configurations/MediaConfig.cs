using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class MediaConfig : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> entity)
        { 
                entity.HasKey(e => e.IdMedia)
                    .HasName("PRIMARY");

                entity.ToTable("media");

                entity.Property(e => e.IdMedia)
                    .HasMaxLength(36)
                    .HasColumnName("idMedia");

                entity.Property(e => e.FechaIngresoMedia).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacionMedia).HasColumnType("datetime");

                entity.Property(e => e.NombreMedia).HasMaxLength(45);

                entity.Property(e => e.UrlMedia).HasMaxLength(45);
        }
    }
}
