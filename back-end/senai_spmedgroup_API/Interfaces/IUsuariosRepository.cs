using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IUsuariosRepository
    {
        List<UsuariosDomain> ListarTodos();
        UsuariosDomain BuscarPorId(int id);
        UsuariosDomain BuscarPorEmailSenha(string email, string senha);
        void Cadastrar(UsuariosDomain usuarioNovo);
        void Atualizar(int id, UsuariosDomain usuarioAtualizado);
        void Deletar(int id);
        UsuariosDomain Login(string email, string senha);
    }
}
