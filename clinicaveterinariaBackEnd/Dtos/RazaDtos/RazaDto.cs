using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Dtos.RazaDtos
{
    public class RazaDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public virtual ICollection<Mascota> mascotas { get; set; }
    }
}
