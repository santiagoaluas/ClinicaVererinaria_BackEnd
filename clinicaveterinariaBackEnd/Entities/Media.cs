using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Media
    {
        public Media()
        {
            Empresas = new HashSet<Empresa>();
        }

        public string IdMedia { get; set; }
        public string NombreMedia { get; set; }
        public string UrlMedia { get; set; }
        public DateTime? FechaIngresoMedia { get; set; }
        public DateTime? FechaModificacionMedia { get; set; }

        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
