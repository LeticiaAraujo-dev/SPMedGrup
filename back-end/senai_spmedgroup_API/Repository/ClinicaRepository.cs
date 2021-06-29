using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        //private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";
        private string stringConexao = "Data Source=LAB08DESK2701\\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";



        public void Atualizar(int id, ClinicaDomain clinicaAtualizada)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE clinica SET cnpj = @cnpj, nomeFantasia = @nomeFantasia,Rua = @rua, Numero = @numero, RazaoSocial = @razaoSocial  WHERE idClinica = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@cnpj", clinicaAtualizada.cnpj);
                    cmd.Parameters.AddWithValue("@nomeFantasia", clinicaAtualizada.nomeFantasia);
                    cmd.Parameters.AddWithValue("@rua", clinicaAtualizada.Rua);
                    cmd.Parameters.AddWithValue("@numero", clinicaAtualizada.Numero);
                    cmd.Parameters.AddWithValue("@razaoSocial", clinicaAtualizada.RazaoSocial);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClinicaDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM clinica WHERE idClinica = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ClinicaDomain clinicaBuscada = new ClinicaDomain()
                        {
                            idClinica = Convert.ToInt32(rdr[0]),
                            cnpj = rdr[1].ToString(),
                            nomeFantasia = rdr[2].ToString(),
                            Rua = rdr[3].ToString(),
                            Numero = Convert.ToInt32(rdr[4]),
                            RazaoSocial = rdr[5].ToString(),
                        };

                        return clinicaBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ClinicaDomain novaClinica)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO clinica(cnpj, nomeFantasia, Rua, Numero, RazaoSocial) VALUES ('" + novaClinica.cnpj + "', '" + novaClinica.nomeFantasia + "', '" + novaClinica.Rua + "', " + novaClinica.Numero + ", '" + novaClinica.RazaoSocial + "')";
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
                string queryDelete = "DELETE FROM clinica WHERE idClinica = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClinicaDomain> ListarTodos()
        {
            List<ClinicaDomain> listaClinicas = new List<ClinicaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM clinica ";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ClinicaDomain clinica = new ClinicaDomain()
                        {
                            idClinica = Convert.ToInt32(rdr[0]),
                            cnpj = rdr[1].ToString(),
                            nomeFantasia = rdr[2].ToString(),
                            Rua = rdr[3].ToString(),
                            Numero = Convert.ToInt32(rdr[4]),
                            RazaoSocial = rdr[5].ToString(),
                        };

                        listaClinicas.Add(clinica);
                    }
                }
            }

            return listaClinicas;
        }
    }
}
