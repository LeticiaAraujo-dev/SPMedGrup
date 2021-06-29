using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        //private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";
        private string stringConexao = "Data Source=LAB08DESK2701\\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";


        public void Atualizar(int id, EspecialidadeDomain especialidadeAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE especialidade SET NomeEspecialidade = @NomeEspecialidade WHERE idEspecialidade = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeEspecialidade", especialidadeAtualizada.NomeEspecialidade);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EspecialidadeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM especialidade WHERE idEspecialidade = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        EspecialidadeDomain especialidadeBuscada = new EspecialidadeDomain()
                        {
                            idEspecialidade = Convert.ToInt32(rdr[0]),
                            NomeEspecialidade = rdr[1].ToString(),
                        };

                        return especialidadeBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(EspecialidadeDomain novaEspecialidade)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO especialidade(NomeEspecialidade) VALUES ('" + novaEspecialidade.NomeEspecialidade + ")";
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
                string queryDelete = "DELETE FROM especialidade WHERE idEspecialidade = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EspecialidadeDomain> ListarTodos()
        {
            List<EspecialidadeDomain> listaEspecialidades = new List<EspecialidadeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM especialidade";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EspecialidadeDomain Especialidade = new EspecialidadeDomain()
                        {
                            idEspecialidade = Convert.ToInt32(rdr[0]),
                            NomeEspecialidade = rdr[1].ToString(),
                        };

                        listaEspecialidades.Add(Especialidade);
                    }
                }
            }

            return listaEspecialidades;
        }
    }
}
