
using senai_spmedgroup.Interfaces;
using SPMedGroup_2._0.Contexts;
using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup_2._0.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {

        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Medico novoMedico)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos
                .ToList();
        }
    }
}
