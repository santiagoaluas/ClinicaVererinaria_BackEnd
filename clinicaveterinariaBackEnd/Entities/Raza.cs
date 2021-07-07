using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Raza
    {
        public Raza()
        {
            Mascota = new HashSet<Mascota>();
        }

        public string IdRaza { get; set; }
        public string NombreRaza { get; set; }
        public string DescripcionRaza { get; set; }

        public virtual ICollection<Mascota> Mascota { get; set; }
    }
}
