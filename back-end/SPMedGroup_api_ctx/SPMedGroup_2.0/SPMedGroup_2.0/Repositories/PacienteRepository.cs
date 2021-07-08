using senai_spmedgroup.Interfaces;
using SPMedGroup_2._0.Contexts;
using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup_2._0.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Paciente pacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public Paciente BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes
                .ToList();
        }
    }
}
