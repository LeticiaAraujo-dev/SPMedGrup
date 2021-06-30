using System;
using System.Collections.Generic;

#nullable disable

namespace SPMedGroup_2._0.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacao { get; set; }
        public string TipoSituacao { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
