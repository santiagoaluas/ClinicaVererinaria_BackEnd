using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class MascotaConfig : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> entity)
        { 
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PRIMARY");

                entity.ToTable("mascota");

                entity.HasIndex(e => e.RazaPaciente, "fk_Paciente_raza1_idx");

                entity.HasIndex(e => e.PesoPaciente, "pesoPaciente_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SexoPaciente, "sexoPaciente_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPaciente)
                    .HasMaxLength(36)
                    .HasColumnName("idPaciente");

                entity.Property(e => e.Alergias).HasColumnType("text");

                entity.Property(e => e.ClientePaciente)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EspeciePaciente)
                    .HasColumnType("int(1)")
                    .HasColumnName("especiePaciente");

                entity.Property(e => e.NombrePaciente)
                    .HasMaxLength(45)
                    .HasColumnName("nombrePaciente");

                entity.Property(e => e.PesoPaciente)
                    .HasPrecision(2, 2)
                    .HasColumnName("pesoPaciente");

                entity.Property(e => e.RazaPaciente)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.SexoPaciente)
                    .HasColumnType("int(1)")
                    .HasColumnName("sexoPaciente");

                entity.HasOne(d => d.RazaPacienteNavigation)
                    .WithMany(p => p.Mascota)
                    .HasForeignKey(d => d.RazaPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Paciente_raza1");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Mascotas)
                    .HasForeignKey(d => d.ClientePaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Mascota_Cliente");
        }
    }
}
