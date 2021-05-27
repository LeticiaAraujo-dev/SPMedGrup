using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Domains
{
    public class MedicoDomain
    {
        public UsuariosDomain Usuario { get; set; }
        public ClinicaDomain Clinica { get; set; }
        public EspecialidadeDomain Especialidade { get; set; }
        public int idMedico { get; set; }
        public string NomeMedico { get; set; }
        public string CRM { get; set; }
    }
}
