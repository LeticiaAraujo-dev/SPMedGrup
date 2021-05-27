using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IMedicoRepository
    {
        List<MedicoDomain> ListarTodos();

        MedicoDomain BuscarPorId(int id);

        void Cadastrar(MedicoDomain novoMedico);

        void Atualizar(int id, MedicoDomain medicoAtualizado);

        void Deletar(int id);
    }
}
