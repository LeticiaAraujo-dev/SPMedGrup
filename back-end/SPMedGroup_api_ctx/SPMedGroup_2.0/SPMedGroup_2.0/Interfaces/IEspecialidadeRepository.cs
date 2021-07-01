using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> ListarTodos();

        Especialidade BuscarPorId(int id);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int id, Especialidade especialidadeAtualizada);

        void Deletar(int id);
    }
}
