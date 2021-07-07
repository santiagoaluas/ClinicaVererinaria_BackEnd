using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Fichaclinicas = new List<Fichaclinica>();
        }

        public string IdUsuario { get; set; }
        public string CedulaUsuario { get; set; }
        public string NombresUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Username { get; set; }
        public string EmailUsuario { get; set; }
        public string TelefonoUsuario { get; set; }
        public int? CargoUsuario { get; set; }
        public string EmpresaUsuarios { get; set; }
        public virtual Empresa EmpresaUsuariosNavigation { get; set; }
        public virtual List<Fichaclinica> Fichaclinicas { get; set; }
    }
}
