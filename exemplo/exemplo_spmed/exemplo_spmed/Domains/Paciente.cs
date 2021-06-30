using System;
using System.Collections.Generic;

#nullable disable

namespace exemplo_spmed.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int? IdUsuario { get; set; }
        public int IdPaciente { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomePaciente { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Cep { get; set; }
        public string Rg { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
