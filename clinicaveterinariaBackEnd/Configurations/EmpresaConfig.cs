using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> entity)
        {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PRIMARY");

                entity.ToTable("empresa");

                entity.HasIndex(e => e.EmpresaMedia, "fk_Empresa_Media1_idx");

                entity.Property(e => e.IdEmpresa)
                    .HasMaxLength(36)
                    .HasColumnName("idEmpresa");

                entity.Property(e => e.DireccionEmpresa)
                    .HasMaxLength(200)
                    .HasColumnName("direccionEmpresa");

                entity.Property(e => e.EmpresaMedia)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(100)
                    .HasColumnName("nombreEmpresa");

                entity.Property(e => e.RucEmpresa)
                    .HasMaxLength(13)
                    .HasColumnName("rucEmpresa");

                entity.Property(e => e.TelefonoEmpresa)
                    .HasMaxLength(10)
                    .HasColumnName("telefonoEmpresa");

                entity.HasOne(d => d.EmpresaMediaNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.EmpresaMedia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Empresa_Media1");
        }
    }
}
