using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> ListarTodos();

        Medico BuscarPorId(int id);

        void Cadastrar(Medico novoMedico);

        void Atualizar(int id, Medico medicoAtualizado);

        void Deletar(int id);
    }
}
