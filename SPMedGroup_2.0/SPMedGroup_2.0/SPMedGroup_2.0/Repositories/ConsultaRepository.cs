using Microsoft.EntityFrameworkCore;
using senai_spmedgroup.Interfaces;
using SPMedGroup_2._0.Contexts;
using SPMedGroup_2._0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedGroup_2._0.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        SPMedContext ctx = new SPMedContext();

        public void Atualizar(int id, Consultum consultaAtualizada)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            if (consultaAtualizada.DataRealizacao != null)
            {
                consultaBuscada.DataRealizacao = consultaAtualizada.DataRealizacao;
            }

            if (consultaAtualizada.IdMedico != null)
            {

                consultaBuscada.IdMedico = consultaAtualizada.IdMedico;
            }

            if (consultaAtualizada.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            if (consultaAtualizada.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(p => p.IdConsulta == id);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consultum consultaBuscada = ctx.Consulta.Find(id);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int id, int idTipoUsuario)
        {
            return ctx.Consulta


                .Include(c => c.IdPacienteNavigation)

                .Include(c => c.IdMedicoNavigation)

                .Include(c => c.IdSituacaoNavigation)

                //.Select(c => new Consultum()
                //{
                //    IdConsulta = c.IdConsulta,
                //    DataRealizacao = c.DataRealizacao,

                //    IdMedicoNavigation = new Medico
                //    {
                //        NomeMedico = c.IdMedicoNavigation.NomeMedico,

                //        IdEspecialidadeNavigation = new Especialidade
                //        {
                //            NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                //        }
                //    },

                //    IdPacienteNavigation = new Paciente
                //    {
                //        IdPaciente = c.IdPacienteNavigation.IdPaciente,
                //        NomePaciente = c.IdPacienteNavigation.NomePaciente
                //    },

                //    IdSituacaoNavigation = new Situacao
                //    {
                //        TipoSituacao = c.IdSituacaoNavigation.TipoSituacao
                //    }

                //})

                .Where(p => p.IdPaciente == id)
                .ToList();
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
