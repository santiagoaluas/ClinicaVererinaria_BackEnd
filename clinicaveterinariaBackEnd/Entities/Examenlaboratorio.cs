using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Examenlaboratorio
    {
        public Examenlaboratorio()
        {
            Fichaclinicas = new HashSet<Fichaclinica>();
        }

        public int IdLaboratorio { get; set; }
        public string Hemograma { get; set; }
        public string Ecg { get; set; }
        public string Radiologia { get; set; }
        public string Ecografia { get; set; }
        public string Deshidratacion { get; set; }

        public virtual ICollection<Fichaclinica> Fichaclinicas { get; set; }
    }
}
