using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class ExamenlaboratorioConfig : IEntityTypeConfiguration<Examenlaboratorio>
    {
        public void Configure(EntityTypeBuilder<Examenlaboratorio> entity)
        { 
                entity.HasKey(e => e.IdLaboratorio)
                    .HasName("PRIMARY");

                entity.ToTable("examenlaboratorio");

                entity.Property(e => e.IdLaboratorio)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("idLaboratorio");

                entity.Property(e => e.Deshidratacion).HasMaxLength(45);

                entity.Property(e => e.Ecg)
                    .HasMaxLength(255)
                    .HasColumnName("ECG");

                entity.Property(e => e.Ecografia).HasMaxLength(255);

                entity.Property(e => e.Hemograma).HasMaxLength(255);

                entity.Property(e => e.Radiologia).HasMaxLength(255);
        }
    }
}
