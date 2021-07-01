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
        //private string stringConexao = "Data Source=LAB08DESK2701\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";


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
                string querySelectById = "SELECT idConsulta, DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao WHERE idConsulta = @ID";

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
                            idConsulta = Convert.ToInt32(rdr[0]),
                            DataRealizacao = Convert.ToDateTime(rdr[1]),
                            Medico = new MedicoDomain
                            {
                                NomeMedico = rdr[2].ToString(),
                                Especialidade = new EspecialidadeDomain
                                {
                                    NomeEspecialidade = rdr[3].ToString(),
                                }
                            },
                            Paciente = new PacienteDomain
                            {
                                NomePaciente = rdr[4].ToString(),
                            },
                            Situacao = new SituacaoDomain
                            {
                                TipoSituacao = rdr[5].ToString(),
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
                string queryInsert = "INSERT INTO consulta(idSituacao, idMedico, idPaciente, DataRealizacao) VALUES (" + novaConsulta.Situacao.idSituacao + ", " + novaConsulta.Medico.idMedico + ", " + novaConsulta.Paciente.idPaciente + ", '" + novaConsulta.DataRealizacao + "')";
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

        public List<ConsultaDomain> ListarMinhas(int id, int idTipoUsuario)
        {
            List<ConsultaDomain> listaConsultaMinhas = new List<ConsultaDomain>();
            switch (idTipoUsuario)
            {
                case 3:
                    using (SqlConnection con = new SqlConnection(stringConexao))
                    {
                        string querySelectUser = "SELECT idPaciente, NomePaciente FROM paciente WHERE idUsuario = @ID";

                        con.Open();

                        SqlDataReader rdrUser;

                        using (SqlCommand cmdUser = new SqlCommand(querySelectUser, con))
                        {
                            cmdUser.Parameters.AddWithValue("@ID", id);

                            rdrUser = cmdUser.ExecuteReader();

                            if (rdrUser.Read())
                            {
                                PacienteDomain PacienteBuscada = new PacienteDomain()
                                {
                                    idPaciente = Convert.ToInt32(rdrUser[0]),
                                    NomePaciente = rdrUser[1].ToString()
                                };

                                string querySelectAll = "SELECT idConsulta, DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao WHERE consulta.idPaciente = @IDPaciente";

                                rdrUser.Close();

                                SqlDataReader rdr;

                                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                                {
                                    cmd.Parameters.AddWithValue("@IDPaciente", PacienteBuscada.idPaciente);

                                    rdr = cmd.ExecuteReader();

                                    while (rdr.Read())
                                    {
                                        ConsultaDomain consulta = new ConsultaDomain()
                                        {
                                            idConsulta = Convert.ToInt32(rdr[0]),
                                            DataRealizacao = Convert.ToDateTime(rdr[1]),
                                            Medico = new MedicoDomain
                                            {
                                                NomeMedico = rdr[2].ToString(),
                                                Especialidade = new EspecialidadeDomain
                                                {
                                                    NomeEspecialidade = rdr[3].ToString(),
                                                }
                                            },
                                            Paciente = new PacienteDomain
                                            {
                                                NomePaciente = rdr[4].ToString(),
                                            },
                                            Situacao = new SituacaoDomain
                                            {
                                                TipoSituacao = rdr[5].ToString(),
                                            }
                                        };
                                        listaConsultaMinhas.Add(consulta);
                                    }
                                }

                            }
                        }
                    }
                    break;

                case 2:
                    using (SqlConnection con = new SqlConnection(stringConexao))
                    {
                        string querySelectUser = "SELECT idMedico, NomeMedico FROM medico WHERE idUsuario = @ID";

                        con.Open();

                        SqlDataReader rdrUser;

                        using (SqlCommand cmdUser = new SqlCommand(querySelectUser, con))
                        {
                            cmdUser.Parameters.AddWithValue("@ID", id);

                            rdrUser = cmdUser.ExecuteReader();

                            if (rdrUser.Read())
                            {
                                MedicoDomain MedicoBuscada = new MedicoDomain()
                                {
                                    idMedico = Convert.ToInt32(rdrUser[0]),
                                    NomeMedico = rdrUser[1].ToString()
                                };

                                string querySelectAll = "SELECT idConsulta, DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao WHERE consulta.idMedico = @IDMedico";

                                rdrUser.Close();

                                SqlDataReader rdr;

                                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                                {
                                    cmd.Parameters.AddWithValue("@IDMedico", MedicoBuscada.idMedico);

                                    rdr = cmd.ExecuteReader();

                                    while (rdr.Read())
                                    {
                                        ConsultaDomain consulta = new ConsultaDomain()
                                        {
                                            idConsulta = Convert.ToInt32(rdr[0]),
                                            DataRealizacao = Convert.ToDateTime(rdr[1]),
                                            Medico = new MedicoDomain
                                            {
                                                NomeMedico = rdr[2].ToString(),
                                                Especialidade = new EspecialidadeDomain
                                                {
                                                    NomeEspecialidade = rdr[3].ToString(),
                                                }
                                            },
                                            Paciente = new PacienteDomain
                                            {
                                                NomePaciente = rdr[4].ToString(),
                                            },
                                            Situacao = new SituacaoDomain
                                            {
                                                TipoSituacao = rdr[5].ToString(),
                                            }
                                        };
                                        listaConsultaMinhas.Add(consulta);
                                    }
                                }

                            }
                        }
                    }
                    break;
            }

            return listaConsultaMinhas;

        }

        public List<ConsultaDomain> ListarTodos()
        {
            List<ConsultaDomain> listaConsulta = new List<ConsultaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idConsulta, DataRealizacao, NomeMedico, NomeEspecialidade, NomePaciente, TipoSituacao FROM consulta INNER JOIN medico ON consulta.idMedico = medico.idMedico INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idEspecialidade INNER JOIN paciente ON paciente.idPaciente = consulta.idPaciente INNER JOIN situacao ON consulta.idSituacao = situacao.idSituacao ";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ConsultaDomain consulta = new ConsultaDomain()
                        {
                            idConsulta = Convert.ToInt32(rdr[0]),
                            DataRealizacao = Convert.ToDateTime(rdr[1]),
                            Medico = new MedicoDomain
                            {
                                NomeMedico = rdr[2].ToString(),
                                Especialidade = new EspecialidadeDomain
                                {
                                    NomeEspecialidade = rdr[3].ToString(),
                                }
                            },
                            Paciente = new PacienteDomain
                            {
                                NomePaciente = rdr[4].ToString(),
                            },
                            Situacao = new SituacaoDomain
                            {
                                TipoSituacao = rdr[5].ToString(),
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
