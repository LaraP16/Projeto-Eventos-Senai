using System;
using System.Collections.Generic;
using System.Data;
using api_eventos.Models;
using api_eventos.Repository;
using MySql.Data.MySqlClient;

namespace api_eventos.DAO
{
    public class IngressoDAO
    {
        private MySqlConnection _connection;

        public IngressoDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Ingresso> GetAll()
        {
            List<Ingresso> ingressos = new List<Ingresso>();
            string query = "SELECT * FROM ingresso";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Ingresso ingresso = new Ingresso();
                    ingresso.idIngresso = reader.GetInt32("idingresso");
                    ingresso.CodigoQr = reader.GetString("codigo_qr");
                    ingresso.Valor = reader.GetDouble("valor");
                    ingresso.Status = reader.GetString("status");
                    ingresso.Tipo = reader.GetString("tipo");
                    ingresso.DataUtilizacao = reader.IsDBNull("data_utilizacao") ? DateTime.MinValue : reader.GetDateTime("data_utilizacao");
                    ingresso.IdPedido = reader.GetInt32("pedido_idpedido");
                    ingresso.IdUsuario = reader.GetInt32("pedido_usuario_idusuario");
                    ingresso.IdLote = reader.GetInt32("lote_idlote");
                    ingresso.IdEvento = reader.GetInt32("evento_idevento");
                    ingressos.Add(ingresso);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return ingressos;
        }

        public Ingresso GetId(int id)
        {
            Ingresso ingresso = new Ingresso();
            var query = $"SELECT * FROM ingresso WHERE idingresso = {id}";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    ingresso.idIngresso = reader.GetInt32("idingresso");
                    ingresso.CodigoQr = reader.GetString("codigo_qr");
                    ingresso.Valor = reader.GetDouble("valor");
                    ingresso.Status = reader.GetString("status");
                    ingresso.Tipo = reader.GetString("tipor");
                    ingresso.DataUtilizacao = reader.GetDateTime("data_utilizacao");
                    ingresso.IdPedido = reader.GetInt32("pedido_idpedido");
                    ingresso.IdUsuario = reader.GetInt32("pedido_usuario_idusuario");
                    ingresso.IdLote = reader.GetInt32("lote_idlote");
                    ingresso.IdEvento = reader.GetInt32("evento_idevento");

                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return ingresso;
        }

        public void CriarIngresso(Ingresso ingresso)
        {
            var query = "INSERT INTO ingresso (codigo_qr, valor, status, tipo, data_utilizacao, pedido_idpedido, pedido_usuario_idusuario, lote_idlote, evento_idevento) VALUES (@codigo_qr, @valor, @status, @tipo, @data_utilizacao, @pedido_idpedido, @pedido_usuario_idusuario, @lote_idlote, @evento_idevento)";

            try
            {
                _connection.Open();
                using var command = new MySqlCommand(query, _connection);

                command.Parameters.AddWithValue("@codigo_qr", ingresso.CodigoQr);
                command.Parameters.AddWithValue("@valor", ingresso.Valor);
                command.Parameters.AddWithValue("@status", ingresso.Status);
                command.Parameters.AddWithValue("@tipo", ingresso.Tipo);
                command.Parameters.AddWithValue("@data_utilizacao", ingresso.DataUtilizacao);
                command.Parameters.AddWithValue("@pedido_idpedido", ingresso.IdPedido);
                command.Parameters.AddWithValue("@pedido_usuario_idusuario", ingresso.IdUsuario);
                command.Parameters.AddWithValue("@lote_idlote", ingresso.IdLote);
                command.Parameters.AddWithValue("@evento_idevento", ingresso.IdEvento);

                command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar ingresso: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void UpDateIngresso(int id, Ingresso ingresso)
        {
            var query = "UPDATE Ingressos SET codigo_qr = @codigo_qr, valor = @valor, status = @status, tipo = @tipo, data_utilizacao = @data_utilizacao, pedido_idpedido = @pedido_idpedido, lote_idlote = @lote_idlote, evento_idevento = @evento_idevento  WHERE idingresso = @idingresso";

            try
            {
                _connection.Open();

                using var command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idingresso", id);
                command.Parameters.AddWithValue("@codigo_qr", ingresso.CodigoQr);
                command.Parameters.AddWithValue("@valor", ingresso.Valor);
                command.Parameters.AddWithValue("@status", ingresso.Status);
                command.Parameters.AddWithValue("@tipo", ingresso.Tipo);
                command.Parameters.AddWithValue("@data_utilizacao", ingresso.DataUtilizacao);
                command.Parameters.AddWithValue("@pedido_idpedido", ingresso.IdPedido);
                command.Parameters.AddWithValue("@pedido_usuario_idusuario", ingresso.IdUsuario);
                command.Parameters.AddWithValue("@lote_idlote", ingresso.IdLote);
                command.Parameters.AddWithValue("@evento_idevento", ingresso.IdEvento);


                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar ingresso: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletarIngresso(int id)
        {
            var query = $"DELETE FROM ingresso WHERE idingresso = @idingresso";

            try
            {
                _connection.Open();
                using var command = new MySqlCommand(query, _connection);

                command.Parameters.AddWithValue("@idingresso", id);
                command.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados MySQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao deletar ingresso: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}