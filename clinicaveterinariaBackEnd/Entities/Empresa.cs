using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Empresa
    {
        public Empresa()
        {
            Clientes = new HashSet<Cliente>();
            Productos = new HashSet<Producto>();
            Usuarios = new HashSet<Usuario>();
        }

        public string IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public string RucEmpresa { get; set; }
        public string EmpresaMedia { get; set; }

        public virtual Media EmpresaMediaNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
