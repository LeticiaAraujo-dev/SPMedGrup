using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";

        public void Atualizar(int id, ConsultaDomain consultaAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE consulta SET idSituacao = @situacao, idMedico = @medico, idPaciente = @paciente, DataRealizacao = @data WHERE idConsulta = @ID;";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@situacao", consultaAtualizada.Situacao.idSituacao);
                    cmd.Parameters.AddWithValue("@medico", consultaAtualizada.Medico.idMedico);
                    cmd.Parameters.AddWithValue("@paciente", consultaAtualizada.Paciente.idPaciente);
                    cmd.Parameters.AddWithValue("@data", consultaAtualizada.DataRealizacao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ConsultaDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao WHERE idConsulta = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ConsultaDomain ConsultaBuscada = new ConsultaDomain()
                        {
                            DataRealizacao = Convert.ToDateTime(rdr[0]),
                            Medico = new MedicoDomain 
                            {
                                NomeMedico = rdr[1].ToString(),
                                Especialidade = new EspecialidadeDomain
                                {
                                    NomeEspecialidade = rdr[2].ToString(),
                                }
                            },
                            Paciente = new PacienteDomain
                            {
                                NomePaciente = rdr[3].ToString(),
                            },
                            Situacao = new SituacaoDomain
                            {
                                TipoSituacao = rdr[4].ToString(),
                            }
                        };

                        return ConsultaBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ConsultaDomain novaConsulta)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO consulta(idSituacao, idMedico, idPaciente, DataRealizacao) VALUES ('" + novaConsulta.Situacao.idSituacao + "', '" + novaConsulta.Medico.idMedico + "', '" + novaConsulta.Paciente.idPaciente + "', " + novaConsulta.DataRealizacao + ")";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM consulta WHERE idConsulta = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ConsultaDomain> ListarTodos()
        {
            List<ConsultaDomain> listaConsulta = new List<ConsultaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao ";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ConsultaDomain consulta = new ConsultaDomain()
                        {
                            DataRealizacao = Convert.ToDateTime(rdr[0]),
                            Medico = new MedicoDomain
                            {
                                NomeMedico = rdr[1].ToString(),
                                Especialidade = new EspecialidadeDomain
                                {
                                    NomeEspecialidade = rdr[2].ToString(),
                                }
                            },
                            Paciente = new PacienteDomain
                            {
                                NomePaciente = rdr[3].ToString(),
                            },
                            Situacao = new SituacaoDomain
                            {
                                TipoSituacao = rdr[4].ToString(),
                            }
                        };

                        listaConsulta.Add(consulta);
                    }
                }
            }

            return listaConsulta;
        }
    }
}
