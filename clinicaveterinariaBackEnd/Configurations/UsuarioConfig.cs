using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        { 
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.EmpresaUsuarios, "fk_Usuario_Empresa1_idx");

                entity.Property(e => e.IdUsuario)
                    .HasMaxLength(36)
                    .HasColumnName("idUsuario");

                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasColumnType("BLOB");

                entity.Property(u => u.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("BLOB");

                entity.Property(e => e.ApellidosUsuario)
                    .HasMaxLength(100)
                    .HasColumnName("apellidosUsuario");

                entity.Property(e => e.CargoUsuario)
                    .HasColumnType("int(2)")
                    .HasColumnName("cargoUsuario");

                entity.Property(e => e.CedulaUsuario)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("cedulaUsuario");

                entity.Property(e => e.EmailUsuario)
                    .HasMaxLength(50)
                    .HasColumnName("emailUsuario");

                entity.Property(e => e.EmpresaUsuarios)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.NombresUsuario)
                    .HasMaxLength(100)
                    .HasColumnName("nombresUsuario");

                entity.Property(e => e.TelefonoUsuario)
                    .HasMaxLength(10)
                    .HasColumnName("telefonoUsuario");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

               

                entity.HasOne(d => d.EmpresaUsuariosNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpresaUsuarios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Empresa1");
        }
    }
}
