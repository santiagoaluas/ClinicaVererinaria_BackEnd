using clinicaveterinariaBackEnd.Dtos.MascotaDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Dtos.ClienteDtos
{
    public class ClienteDto
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string empresa { get; set; }
        public string id { get; set; }

        public virtual ICollection<MascotaDto> Mascotas { get; set; }
    }
}
