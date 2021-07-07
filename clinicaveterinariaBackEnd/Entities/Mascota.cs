using System;
using System.Collections.Generic;

#nullable disable

namespace clinicaveterinariaBackEnd.Entities
{
    public partial class Mascota
    {
        public Mascota()
        {
            Fichaclinicas = new HashSet<Fichaclinica>();
        }

        public string IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public int? EspeciePaciente { get; set; }
        public int? SexoPaciente { get; set; }
        public decimal? PesoPaciente { get; set; }
        public string RazaPaciente { get; set; }
        public string ClientePaciente { get; set; }
        public string Alergias { get; set; }

        public virtual Raza RazaPacienteNavigation { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<Fichaclinica> Fichaclinicas { get; set; }

    }
}
