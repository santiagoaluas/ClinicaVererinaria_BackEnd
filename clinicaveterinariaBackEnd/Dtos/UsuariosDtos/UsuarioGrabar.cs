using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Dtos.UsuariosDtos
{
    public class UsuarioGrabar
    {
        public string cedula { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string username { get; set; }

        public string password { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public int? cargo { get; set; }
        public string empresa { get; set; }
    }
}
