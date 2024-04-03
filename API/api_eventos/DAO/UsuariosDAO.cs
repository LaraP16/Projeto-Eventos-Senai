using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_eventos.Models;
using api_eventos.Repository;
using MySql.Data.MySqlClient;

namespace api_eventos.DAO
{
    public class UsuariosDAO
    {
        private MySqlConnection _connection;

        public UsuariosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string query = "SELECT * FROM Usuario";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = reader.GetInt32("idusuario");
                        usuario.NomeCompleto = reader.GetString("nome_completo");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Telefone = reader.GetString("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.Ativo = reader.GetString("ativo");
                        usuarios.Add(usuario);
                    }
                }
            }
            catch (MySqlException ex)
            { //mapeando os erros do banco
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {// erros de forma geral
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                //fecha a conexão com o banco
                _connection.Close();
            }

            return usuarios;
        }

        public Usuario GetId(int id)
        {
            Usuario usuario = new Usuario();
            string query = $"SELECT * FROM usuario WHERE idusuario = {id}";
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using(MySqlDataReader reader = command.ExecuteReader())
                {

                    if(reader.Read())
                    {
                        usuario.IdUsuario = reader.GetInt32("idusuario");
                        usuario.NomeCompleto = reader.GetString("nome_completo");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.Telefone = reader.GetString("telefone");
                        usuario.Perfil = reader.GetString("perfil");
                        usuario.Ativo = reader.GetString("ativo");
                    }
                }  
            }
            catch(MySqlException ex)
            {
                Console.WriteLine($"Erro no banco: {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return usuario;
        }
        public void CriarUsuario(Usuario usuario)
        {
            string query = "INSERT INTO usuario (nome_completo, email, senha, telefone, perfil, ativo) VALUES (@NomeCompleto, @Email, @Senha, @Telefone, @Perfil, @Ativo)";

        try
        {
            _connection.Open();
            using (var command = new MySqlCommand(query,_connection))
            {
                command.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);
                command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                command.Parameters.AddWithValue("@Ativo", usuario.Ativo);
                command.ExecuteNonQuery();
            }
        }
        catch(MySqlException ex)
        {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
        }
        finally
        {
            _connection.Close();
        }
        }
        
        public void AtualizarUsuario(int id, Usuario usuario)
        {
            string query = "UPDATE usuario SET" +
                           "nomecompleto=@NomeCompleto, " +
                           "email=@Email, " +
                           "senha=@Senha, " +
                           "telefone=@Telefone, " +
                           "perfil=@Perfil, " + 
                           "ativo=@Ativo " + 
                           "WHERE idusuario=@IdUsuario";

            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.Parameters.AddWithValue("@NomeCompleto", usuario.NomeCompleto);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Senha", usuario.Senha);
                    command.Parameters.AddWithValue("@Telefone", usuario.Telefone);
                    command.Parameters.AddWithValue("@Perfil", usuario.Perfil);
                    command.Parameters.AddWithValue("@Ativo", usuario.Ativo);
                    command.ExecuteNonQuery();
                }
            }
             catch(MySqlException ex)
            {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletarUsuario(int id)
        {
            string query = "DELETE FROM usuario WHERE IdUsuario = @IdUsuario";
            
            try
            {
                _connection.Open();
                using(var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", id);
                    command.ExecuteNonQuery();
                }
            }
             catch(MySqlException ex)
            {
            Console.WriteLine($"Erro de Banco: {ex.Message}");
            }
            catch(Exception ex)
            {
            Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }
    }
    
}