using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuario> ListarTodos();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario usuarioNovo);
        void Atualizar(int id, Usuario usuarioAtualizado);
        void Deletar(int id);
        Usuario Login(string email, string senha);
    }
}
