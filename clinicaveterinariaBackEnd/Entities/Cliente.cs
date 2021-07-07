using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Mascotas = new HashSet<Mascota>();
        }
        public string CedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string EmailCliente { get; set; }
        public string EmpresaCliente { get; set; }
        public string IdCliente { get; set; }

        public virtual Empresa EmpresaClienteNavigation { get; set; }
        public virtual ICollection<Mascota> Mascotas { get; set; }

    }
}
