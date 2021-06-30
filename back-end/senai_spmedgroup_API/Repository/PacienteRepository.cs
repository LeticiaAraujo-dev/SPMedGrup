using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";
        //private string stringConexao = "Data Source=LAB08DESK2701\\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";


        public void Atualizar(int id, PacienteDomain pacienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE paciente SET idUsuario = @idUsuario, DataNascimento = @DataNascimento, NomePaciente = @NomePaciente, Telefone = @Telefone, CPF = @CPF, Rua = @Rua, Numero = @Numero, CEP = @CEP, RG = @RG WHERE idPaciente = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idUsuario", pacienteAtualizado.Usuario.idUsuario);
                    cmd.Parameters.AddWithValue("@DataNascimento", pacienteAtualizado.DataNascimento);
                    cmd.Parameters.AddWithValue("@NomePaciente", pacienteAtualizado.NomePaciente);
                    cmd.Parameters.AddWithValue("@Rua", pacienteAtualizado.Rua);
                    cmd.Parameters.AddWithValue("@Numero", pacienteAtualizado.Numero);
                    cmd.Parameters.AddWithValue("@Telefone", pacienteAtualizado.Telefone);
                    cmd.Parameters.AddWithValue("@CPF", pacienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@CEP", pacienteAtualizado.CEP);
                    cmd.Parameters.AddWithValue("@RG", pacienteAtualizado.RG);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public PacienteDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT NomePaciente, CPF, RG, DataNascimento, Telefone, CEP, Rua, Numero, email AS Email FROM paciente INNER JOIN usuarios ON paciente.idUsuario = usuarios.idUsuario WHERE idPaciente = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        PacienteDomain PacienteBuscada = new PacienteDomain()
                        {
                            NomePaciente = rdr[0].ToString(),
                            CPF = Convert.ToInt32(rdr[1]),
                            RG = Convert.ToInt32(rdr[2]),
                            DataNascimento = Convert.ToDateTime(rdr[3]),
                            Telefone = Convert.ToInt32(rdr[4]),
                            CEP = Convert.ToInt32(rdr[5]),
                            Rua = rdr[6].ToString(),
                            Numero = Convert.ToInt32(rdr[7]),
                            Usuario = new UsuariosDomain
                            { 
                                email = rdr[8].ToString()
                            }

                        };

                        return PacienteBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(PacienteDomain novoPaciente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO paciente(idUsuario, DataNascimento, NomePaciente, Telefone, CPF, Rua, Numero, CEP, RG)  VALUES ('" + novoPaciente.Usuario.idUsuario + "', '" + novoPaciente.DataNascimento + "', '" + novoPaciente.NomePaciente + "', " + novoPaciente.Telefone + ", " + novoPaciente.CPF + ", '"+ novoPaciente .Rua + "', "+ novoPaciente.Numero + ", "+ novoPaciente.CEP + ", "+ novoPaciente.RG + ")";
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
                string queryDelete = "DELETE FROM paciente WHERE idPaciente = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<PacienteDomain> ListarTodos()
        {
            List<PacienteDomain> listaPacientes = new List<PacienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT NomePaciente, CPF, RG, DataNascimento, Telefone, CEP, Rua, Numero, email AS Email FROM paciente INNER JOIN usuarios ON paciente.idUsuario = usuarios.idUsuario";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PacienteDomain paciente = new PacienteDomain()
                        {
                            NomePaciente = rdr[0].ToString(),
                            CPF = Convert.ToInt32(rdr[1]),
                            RG = Convert.ToInt32(rdr[2]),
                            DataNascimento = Convert.ToDateTime(rdr[3]),
                            Telefone = Convert.ToInt32(rdr[4]),
                            CEP = Convert.ToInt32(rdr[5]),
                            Rua = rdr[6].ToString(),
                            Numero = Convert.ToInt32(rdr[7]),
                            Usuario = new UsuariosDomain
                            {
                                email = rdr[8].ToString()
                            }
                        };

                        listaPacientes.Add(paciente);
                    }
                }
            }

            return listaPacientes;
        }
    }
}
