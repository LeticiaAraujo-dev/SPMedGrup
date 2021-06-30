using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedGroup_2._0.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string RazaoSocial { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
