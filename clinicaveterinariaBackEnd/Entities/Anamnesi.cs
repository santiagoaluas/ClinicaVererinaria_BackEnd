using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Anamnesi
    {
        public int IdAnamnesis { get; set; }
        public string Liquido { get; set; }
        public string Solido { get; set; }
        public string Tratamiento { get; set; }
        public int? Horas { get; set; }
        public string FichaClinica { get; set; }

        public virtual Fichaclinica FichaClinicaNavigation { get; set; }
    }
}
