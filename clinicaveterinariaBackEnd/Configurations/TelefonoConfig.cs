using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class TelefonoConfig : IEntityTypeConfiguration<Telefono>
    {
        public void Configure(EntityTypeBuilder<Telefono> entity)
        {
            entity.HasNoKey();

            entity.ToTable("telefono");

            entity.Property(e => e.ClientesTelefonos)
                .IsRequired()
                .HasMaxLength(10);

            entity.Property(e => e.NumeroTelefono)
                        .HasMaxLength(45)
                        .HasColumnName("numeroTelefono");

            entity.Property(e => e.TipoTelefono)
                        .HasColumnType("int(1)")
                        .HasColumnName("tipoTelefono");
        }
    }
}
