using senai_spmedgroup.Domains;
using senai_spmedgroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        //private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=SPMedGroup; user Id=sa; pwd=Leticia0304";
        private string stringConexao = "Data Source=LAB08DESK2701\\SQLEXPRESS01; initial catalog=SPMedGroup; user Id=sa; pwd=sa132";
        

        public void Atualizar(int id, UsuariosDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE usuarios SET email = @Nome, senha = @Senha WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", usuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@Senha", usuarioAtualizado.senha);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public UsuariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT email AS 'Email', NomeTipoUsuario AS 'Tipo de Usuario' FROM usuarios LEFT JOIN tiposUsuarios ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario WHERE idUsuario = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        UsuariosDomain usuarioBuscado = new UsuariosDomain()
                        {
                            email = rdr[0].ToString(),
                            TipoUsuario = new TiposUsuariosDomain
                            {
                                NomeTipoUsuario = rdr[1].ToString()
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(UsuariosDomain usuarioNovo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO usuarios(idTipoUsuario, email, senha) VALUES ('" + usuarioNovo.TipoUsuario.idTipoUsuario + "', '" + usuarioNovo.email + "', '" + usuarioNovo.senha + "')";
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
                string queryDelete = "DELETE FROM usuarios WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuariosDomain> ListarTodos()
        {
            List<UsuariosDomain> listaUsuarios = new List<UsuariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idUsuario AS 'Id do Usuario', email AS 'Email', NomeTipoUsuario AS 'Tipo de Usuario' FROM usuarios LEFT JOIN tiposUsuarios ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        UsuariosDomain usuario = new UsuariosDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TiposUsuariosDomain
                            {
                                NomeTipoUsuario = rdr[1].ToString()
                            }
                        };

                        listaUsuarios.Add(usuario);
                    }
                }
            }

            return listaUsuarios;
        }

        public UsuariosDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, NomeTipoUsuario, tiposUsuarios.idTipoUsuario " +
                    "FROM usuarios LEFT JOIN tiposUsuarios ON usuarios.idTipoUsuario = tiposUsuarios.idTipoUsuario WHERE email = @email AND senha = @senha ";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuariosDomain usuarioBuscado = new UsuariosDomain
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            TipoUsuario = new TiposUsuariosDomain
                            {
                                NomeTipoUsuario = rdr[2].ToString(),
                                idTipoUsuario = Convert.ToInt32(rdr[3])
                            }
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
