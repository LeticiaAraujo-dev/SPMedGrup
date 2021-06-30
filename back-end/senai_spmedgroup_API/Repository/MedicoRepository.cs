using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        //private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";
        private string stringConexao = "Data Source=LAB08DESK2701\\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";


        public void Atualizar(int id, MedicoDomain medicoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE medico SET idClinica = @idClinica, idEspecialidade = @idEspecialidade, idUsuario = @idUsuario, NomeMedico = @NomeMedico, CRM = @CRM WHERE idMedico = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idClinica", medicoAtualizado.Clinica.idClinica);
                    cmd.Parameters.AddWithValue("@idEspecialidade", medicoAtualizado.Especialidade.idEspecialidade);
                    cmd.Parameters.AddWithValue("@idUsuario", medicoAtualizado.Usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@NomeMedico", medicoAtualizado.NomeMedico);
                    cmd.Parameters.AddWithValue("@CRM", medicoAtualizado.CRM);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public MedicoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeFantasia AS Clinica, NomeMedico AS Nome, NomeEspecialidade AS Especialidade, email AS Email  FROM medico INNER JOIN clinica ON clinica.idClinica = medico.idClinica INNER JOIN usuarios ON usuarios.idUsuario = medico.idUsuario INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idClinica WHERE idMedico = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MedicoDomain medicoBuscado = new MedicoDomain()
                        {
                            Clinica = new ClinicaDomain
                            {
                                nomeFantasia = rdr[0].ToString(),
                            },
                            NomeMedico = rdr[1].ToString(),
                            Especialidade = new EspecialidadeDomain
                            { 
                                NomeEspecialidade = rdr[2].ToString(),
                            },

                            Usuario = new UsuariosDomain
                            {
                                email = rdr[3].ToString(),
                            }

                        };

                        return medicoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(MedicoDomain novoMedico)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO medico(idUsuario, idClinica, idEspecialidade, NomeMedico, CRM) VALUES ('" + novoMedico.Usuario.idUsuario + "', '" + novoMedico.Clinica.idClinica + "', '" + novoMedico.Especialidade.idEspecialidade + "', " + novoMedico.NomeMedico + ", '" + novoMedico.CRM + "')";
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
                string queryDelete = "DELETE FROM medico WHERE idMedico = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<MedicoDomain> ListarTodos()
        {
            List<MedicoDomain> listaMedicos = new List<MedicoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeFantasia AS Clinica, NomeMedico AS Nome, NomeEspecialidade AS Especialidade, email AS Email  FROM medico INNER JOIN clinica ON clinica.idClinica = medico.idClinica INNER JOIN usuarios ON usuarios.idUsuario = medico.idUsuario INNER JOIN especialidade ON especialidade.idEspecialidade = medico.idClinica";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        MedicoDomain medico = new MedicoDomain()
                        {
                            Clinica = new ClinicaDomain
                            {
                                nomeFantasia = rdr[0].ToString(),
                            },
                            NomeMedico = rdr[1].ToString(),
                            Especialidade = new EspecialidadeDomain
                            {
                                NomeEspecialidade = rdr[2].ToString(),
                            },

                            Usuario = new UsuariosDomain
                            {
                                email = rdr[3].ToString(),
                            }
                        };

                        listaMedicos.Add(medico);
                    }
                }
            }

            return listaMedicos;
        }
    }
}
