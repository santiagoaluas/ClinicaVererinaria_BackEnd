using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Telefono
    {
        public int TipoTelefono { get; set; }
        public string NumeroTelefono { get; set; }
        public string ClientesTelefonos { get; set; }
    }
}
