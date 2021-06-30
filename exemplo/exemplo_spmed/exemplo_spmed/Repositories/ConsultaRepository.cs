using exemplo_spmed.Contexts;
using exemplo_spmed.Domains;
using Microsoft.EntityFrameworkCore;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exemplo_spmed.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Consultum consultaAtualizada)
        {
            throw new NotImplementedException();
        }

        public Consultum BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarMinhas(int id, int idTipoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta
                .Include(c => c.IdPacienteNavigation)
                .Select(c => new Consultum()
                { 
                    IdConsulta = c.IdConsulta,
                    DataRealizacao = c.DataRealizacao,

                    IdMedicoNavigation = new Medico
                    {
                        NomeMedico = c.IdMedicoNavigation.NomeMedico,

                        IdEspecialidadeNavigation = new Especialidade
                        {
                            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                        }
                    },

                    IdPacienteNavigation = new Paciente
                    {
                        NomePaciente = c.IdPacienteNavigation.NomePaciente
                    },

                    IdSituacaoNavigation = new Situacao
                    {
                        TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                    }

                })
                .ToList();
        }
    }
}
