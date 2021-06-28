using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<EspecialidadeDomain> ListarTodos();

        EspecialidadeDomain BuscarPorId(int id);

        void Cadastrar(EspecialidadeDomain novaEspecialidade);

        void Atualizar(int id, EspecialidadeDomain especialidadeAtualizada);

        void Deletar(int id);
    }
}
