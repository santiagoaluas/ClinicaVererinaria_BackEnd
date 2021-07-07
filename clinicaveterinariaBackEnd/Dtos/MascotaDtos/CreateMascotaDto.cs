using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Dtos.MascotaDtos
{
    public class CreateMascotaDto
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public int? especie { get; set; }
        public int? sexo { get; set; }
        public decimal? peso { get; set; }
        public string raza { get; set; }
        public string cliente { get; set; }
        public string alergias { get; set; }
    }
}
