using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Domains
{
    public class ClinicaDomain
    {
        public int idClinica { get; set; }

        [Required(ErrorMessage = "O cnpj da empresa é obrigatório!")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório!")]
        public string nomeFantasia { get; set; }

        public string Rua { get; set; }
        public int Numero { get; set; }

        [Required(ErrorMessage = "A Razão Social da empresa é obrigatória!")]
        public string RazaoSocial { get; set; }
    }
}
