using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Producto
    {
        public string IdProducto { get; set; }
        public string Codigoventa { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Precioventa { get; set; }
        public string Empresa { get; set; }

        public virtual Empresa EmpresaNavigation { get; set; }
    }
}
