using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Configurations
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        { 
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.Empresa, "fk_Producto_Empresa1_idx");

                entity.Property(e => e.IdProducto)
                    .HasMaxLength(36)
                    .HasColumnName("idProducto");

                entity.Property(e => e.Codigoventa)
                    .HasMaxLength(45)
                    .HasColumnName("codigoventa");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(36);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasPrecision(6, 4)
                    .HasColumnName("precio");

                entity.Property(e => e.Precioventa)
                    .HasPrecision(6, 4)
                    .HasColumnName("precioventa");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Producto_Empresa1");
        }
    }
}
