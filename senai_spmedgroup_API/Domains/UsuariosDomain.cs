using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Domains
{
    public class UsuariosDomain
    {
        public int idUsuario { get; set; }
        public TiposUsuariosDomain TipoUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
