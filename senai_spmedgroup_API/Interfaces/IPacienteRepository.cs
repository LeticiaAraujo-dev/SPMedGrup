using senai_spmedgroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IPacienteRepository
    {
        List<PacienteDomain> ListarTodos();

        PacienteDomain BuscarPorId(int id);

        void Cadastrar(PacienteDomain novoPaciente);

        void Atualizar(int id, PacienteDomain pacienteAtualizado);

        void Deletar(int id);
    }
}
