using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class FichaclinicaConfig : IEntityTypeConfiguration<Fichaclinica>
    {
        public void Configure(EntityTypeBuilder<Fichaclinica> entity)
        { 
                entity.HasKey(e => e.IdFichaClinica)
                    .HasName("PRIMARY");

                entity.ToTable("fichaclinica");

                entity.HasIndex(e => e.ExamenLaboratorio, "fk_FichaClinica_ExamenLaboratorio1_idx");

                entity.HasIndex(e => e.Mascota, "fk_FichaClinica_Paciente1_idx");

                entity.HasIndex(e => e.Usuario, "fk_FichaClinica_Usuarios1_idx");

                entity.Property(e => e.IdFichaClinica)
                    .HasMaxLength(36)
                    .HasColumnName("idFichaClinica");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ExamenLaboratorio).HasColumnType("int(11)");

                entity.Property(e => e.FechaIngresoFichaClinica).HasColumnType("datetime");

                entity.Property(e => e.Mascota)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.HasOne(d => d.ExamenLaboratorioNavigation)
                    .WithMany(p => p.Fichaclinicas)
                    .HasForeignKey(d => d.ExamenLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FichaClinica_ExamenLaboratorio1");

                entity.HasOne(d => d.MascotaNavigation)
                    .WithMany(p => p.Fichaclinicas)
                    .HasForeignKey(d => d.Mascota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FichaClinica_Paciente1");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Fichaclinicas)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_FichaClinica_Usuarios1");
        }
    }
}
