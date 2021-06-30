using System;
using System.Collections.Generic;

#nullable disable

namespace exemplo_spmed.Domains
{
    public partial class Consultum
    {
        public int? IdSituacao { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
        public int IdConsulta { get; set; }
        public DateTime? DataRealizacao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
