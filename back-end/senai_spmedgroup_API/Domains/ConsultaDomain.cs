using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Domains
{
    public class ConsultaDomain
    {
        public int idMedico { get; set; }
        public int idPaciente { get; set; }
        public int idSituacao { get; set; }
        public SituacaoDomain Situacao { get; set; }
        public MedicoDomain Medico { get; set; }
        public PacienteDomain Paciente { get; set; }
        public int idConsulta { get; set; }
        public DateTime DataRealizacao { get; set; }
    }
}
