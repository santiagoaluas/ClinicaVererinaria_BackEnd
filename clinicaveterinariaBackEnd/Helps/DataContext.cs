using clinicaveterinariaBackEnd.Configurations;
using clinicaveterinariaBackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Helps
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public virtual DbSet<Anamnesi> Anamneses { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Examenlaboratorio> Examenlaboratorios { get; set; }
        public virtual DbSet<Fichaclinica> Fichaclinicas { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Raza> Razas { get; set; }
        public virtual DbSet<Telefono> Telefonos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AnamnesiConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new EmpresaConfig());
            modelBuilder.ApplyConfiguration(new ExamenlaboratorioConfig());
            modelBuilder.ApplyConfiguration(new FichaclinicaConfig());
            modelBuilder.ApplyConfiguration(new MascotaConfig());
            modelBuilder.ApplyConfiguration(new MediaConfig());
            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new RazaConfig());
            modelBuilder.ApplyConfiguration(new TelefonoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }

    }
}
