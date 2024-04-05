using System;
using System.Collections.Generic;
using api_eventos.Models;
using api_eventos.Repository;
using MySql.Data.MySqlClient;

namespace api.DAO
{
    public class PedidosDAO
    {
        private MySqlConnection _connection;

        public PedidosDAO()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Pedidos> GetAll()
        {
            List<Pedidos> listaPedidos = new List<Pedidos>();
            string query = "SELECT * FROM pedido";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedidos pedido = new Pedidos();
                        pedido.IdPedido = reader.GetInt32("idpedido");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetDouble("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Status = reader.GetString("status");
                        pedido.ValidacaoIdUsuario = reader.GetInt32("validacao_id_usuario");
                        pedido.IdUsuario = reader.GetInt32("usuario_idusuario");
                        listaPedidos.Add(pedido);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return listaPedidos;
        }

        public Pedidos GetId(int id)
        {
            Pedidos pedido = new Pedidos();
            string query = "SELECT * FROM pedidos WHERE idpedido = @Id";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //pedido = new Pedidos();
                        pedido.IdPedido = reader.GetInt32("idpedido");
                        pedido.Data = reader.GetDateTime("data");
                        pedido.Total = reader.GetDouble("total");
                        pedido.Quantidade = reader.GetInt32("quantidade");
                        pedido.FormaPagamento = reader.GetString("forma_pagamento");
                        pedido.Status = reader.GetString("status");
                        pedido.ValidacaoIdUsuario = reader.GetInt32("validacao_id_usuario");
                        pedido.IdUsuario = reader.GetInt32("usuario_idusuario");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
            return pedido;
        }

        public void CriarPedidos(Pedidos pedido)
        {
            string query = "INSERT INTO pedido (data, total, quantidade, forma_pagamento, status, validacao_id_usuario, usuario_idusuario) VALUES (@Data, @Total, @Quantidade, @FormaPagamento, @Status, @Validacao, @UsuarioId)";
            
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Data", pedido.Data);
                command.Parameters.AddWithValue("@Total", pedido.Total);
                command.Parameters.AddWithValue("@Quantidade", pedido.Quantidade);
                command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
                command.Parameters.AddWithValue("@Status", pedido.Status);
                command.Parameters.AddWithValue("@Validacao", pedido.ValidacaoIdUsuario);
                command.Parameters.AddWithValue("@UsuarioId", pedido.IdUsuario);
                
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {rowsAffected}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void AtualizarPedidos(int id, Pedidos pedido)
        {
            string query = "UPDATE pedido SET data = @Data, total = @Total, quantidade = @Quantidade, forma_pagamento = @FormaPagamento, status = @Status, validacao_id_usuario = @Validacao, usuario_idusuario = @UsuarioId WHERE idpedido = @Id";
            
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Data", pedido.Data);
                command.Parameters.AddWithValue("@Total", pedido.Total);
                command.Parameters.AddWithValue("@Quantidade", pedido.Quantidade);
                command.Parameters.AddWithValue("@FormaPagamento", pedido.FormaPagamento);
                command.Parameters.AddWithValue("@Status", pedido.Status);
                command.Parameters.AddWithValue("@Validacao", pedido.ValidacaoIdUsuario);
                command.Parameters.AddWithValue("@UsuarioId", pedido.IdUsuario);
                
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {rowsAffected}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        public void DeletarPedidos(int id)
        {
            string query = "DELETE FROM pedidos WHERE id_pedidos = @Id";
            
            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", id);
                
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Linhas afetadas: {rowsAffected}");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do BANCO: {ex.Message}");
            }
            catch (Exception ex)
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

