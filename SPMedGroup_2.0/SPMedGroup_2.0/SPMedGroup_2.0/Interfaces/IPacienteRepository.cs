using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();

        Paciente BuscarPorId(int id);

        void Cadastrar(Paciente novoPaciente);

        void Atualizar(int id, Paciente pacienteAtualizado);

        void Deletar(int id);
    }
}
