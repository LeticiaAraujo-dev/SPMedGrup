using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Domains
{
    public class PacienteDomain
    {
        public UsuariosDomain Usuario { get; set; }
        public int idPaciente { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomePaciente { get; set; }
        public int Telefone { get; set; }
        public int CPF { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public int RG { get; set; }
    }
}
