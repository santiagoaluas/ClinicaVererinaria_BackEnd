using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class AnamnesiConfig : IEntityTypeConfiguration<Anamnesi>
    {
        public void Configure(EntityTypeBuilder<Anamnesi> entity)
        { 
                entity.HasKey(e => e.IdAnamnesis)
                    .HasName("PRIMARY");

                entity.ToTable("anamnesis");

                entity.HasIndex(e => e.FichaClinica, "fk_Anamnesis_FichaClinica1_idx");

                entity.Property(e => e.IdAnamnesis)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idAnamnesis");

                entity.Property(e => e.FichaClinica)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.Horas)
                    .HasColumnType("int(2)")
                    .HasColumnName("horas");

                entity.Property(e => e.Liquido)
                    .HasMaxLength(45)
                    .HasColumnName("liquido");

                entity.Property(e => e.Solido)
                    .HasMaxLength(45)
                    .HasColumnName("solido");

                entity.Property(e => e.Tratamiento)
                    .HasColumnType("text")
                    .HasColumnName("tratamiento");

                entity.HasOne(d => d.FichaClinicaNavigation)
                    .WithMany(p => p.Anamnesis)
                    .HasForeignKey(d => d.FichaClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Anamnesis_FichaClinica1");
        }
    }
}
