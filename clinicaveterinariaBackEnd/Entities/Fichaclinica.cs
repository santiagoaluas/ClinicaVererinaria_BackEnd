using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Fichaclinica
    {
        public Fichaclinica()
        {
            Anamnesis = new HashSet<Anamnesi>();
        }

        public string IdFichaClinica { get; set; }
        public DateTime? FechaIngresoFichaClinica { get; set; }
        public string Usuario { get; set; }
        public string Cliente { get; set; }
        public string Mascota { get; set; }
        public int ExamenLaboratorio { get; set; }

        public virtual Examenlaboratorio ExamenLaboratorioNavigation { get; set; }
        public virtual Mascota MascotaNavigation { get; set; }
        public virtual Usuario UsuarioNavigation { get; set; }
        public virtual ICollection<Anamnesi> Anamnesis { get; set; }
    }
}
