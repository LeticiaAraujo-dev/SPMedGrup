using exemplo_spmed.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodos();

        Consultum BuscarPorId(int id);

        void Cadastrar(Consultum novaConsulta);

        void Atualizar(int id, Consultum consultaAtualizada);

        void Deletar(int id);

        List<Consultum> ListarMinhas(int id, int idTipoUsuario);
    }
}
