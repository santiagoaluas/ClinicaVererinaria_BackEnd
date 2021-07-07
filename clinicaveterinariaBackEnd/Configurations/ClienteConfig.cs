using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entity)
        {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.CedulaCliente, "cedulaCliente_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.EmpresaCliente, "fk_Cliente_Empresa1_idx");

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(36)
                    .HasColumnName("idCliente");

                entity.Property(e => e.CedulaCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cedulaCliente");

                entity.Property(e => e.DireccionCliente)
                    .HasMaxLength(200)
                    .HasColumnName("direccionCliente");

                entity.Property(e => e.EmailCliente)
                    .HasMaxLength(100)
                    .HasColumnName("emailCliente");

                entity.Property(e => e.EmpresaCliente)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(100)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.ApellidoCliente)
                    .HasMaxLength(100)
                    .HasColumnName("apellidoCliente");

            entity.HasOne(d => d.EmpresaClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.EmpresaCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cliente_Empresa1");
        }
    }
}
