using System;
using System.Collections.Generic;
using api.Models;
using api_eventos.Repository;
using MySql.Data.MySqlClient;

namespace api.DAO
{
    public class EventoDao
    {
        private MySqlConnection _connection;

        public EventoDao()
        {
            _connection = MySqlConnectionFactory.GetConnection();
        }

        public List<Evento> GetAll()
        {
            List<Evento> eventos = new List<Evento>();
            string query = "SELECT * FROM evento";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evento evento = new Evento();
                        evento.IdEvento = reader.GetInt32("idevento");
                        evento.Descricao = reader.GetString("descricao");
                        evento.TotalIngresso = reader.GetDecimal("total_ingresso");
                        evento.DataEvento = reader.GetDateTime("data_evento");
                        evento.ImagemUrl = reader.GetString("imagem_url");
                        evento.Local = reader.GetString("local");
                        evento.Ativo = reader.GetInt16("ativo");
                    
                        eventos.Add(evento);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return eventos;
        }

        public Evento GetById(int id)
        {
            Evento evento = new Evento();
            string query = $"SELECT * FROM evento WHERE idevento = {id};";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    evento.IdEvento = reader.GetInt32("idevento");
                    evento.Descricao = reader.GetString("descricao");
                    evento.TotalIngresso = reader.GetDecimal("total_ingresso");
                    evento.DataEvento = reader.GetDateTime("data_evento");
                    evento.ImagemUrl = reader.GetString("imagem_url");
                    evento.Local = reader.GetString("local");
                    evento.Ativo = reader.GetInt16("ativo");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do Banco: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro Desconhecido: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return evento;
        }

        public void CreateEvento(Evento evento)
        {
            string query = "INSERT INTO evento (descricao, total_ingresso, data_evento, imagem_url, local, ativo) VALUES (@Descricao, @TotalIngresso, @DataEvento, @ImagemUrl, @Local, @Ativo)";

            try
            {
                _connection.Open();
                using var command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Descricao", evento.Descricao);
                command.Parameters.AddWithValue("@TotalIngresso", evento.TotalIngresso);
                command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);
                command.Parameters.AddWithValue("@ImagemUrl", evento.ImagemUrl);
                command.Parameters.AddWithValue("@Local", evento.Local);
                command.Parameters.AddWithValue("@Ativo", evento.Ativo);

                command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Erro do Banco: {ex.Message}");
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

        public void UpdateEvento(int id, Evento evento)
        {
            //UPDATE `bd_eventos_senailp`.`evento` SET `total_ingresso` = '500' WHERE (`idevento` = '3');

            string query = "UPDATE evento SET " +
                            "descricao = @descricao, " +
                            "total_ingresso = @total_ingresso, " +
                            "data_evento = @data_evento, " +
                            "imagem_url=@imagem_url, " +
                            "local = @local, " +
                            "ativo = @ativo " + 
                            "WHERE idevento=@idevento";

            try
            {
                 _connection.Open();
                using var command = new MySqlCommand(query, _connection);

                command.Parameters.AddWithValue("@idevento", id);
                command.Parameters.AddWithValue("@descricao", evento.Descricao);
                command.Parameters.AddWithValue("@total_ingresso", evento.TotalIngresso);
                command.Parameters.AddWithValue("@data_evento", evento.DataEvento);
                command.Parameters.AddWithValue("@imagem_url", evento.ImagemUrl);
                command.Parameters.AddWithValue("@local", evento.Local);
                command.Parameters.AddWithValue("@ativo", evento.Ativo);

                command.ExecuteNonQuery();
            }

             catch(MySqlException ex)
            {   
                Console.WriteLine($"Erro do Banco: + {ex.Message}");
            }

        catch(Exception ex)
            { 
                Console.WriteLine($"Erro Desconhecido: + {ex.Message}");
            }

        finally
            {   
                _connection.Close();
            }
        }

        public void DeleteEvento(int id)
        {
             string query = " DELETE FROM evento WHERE idevento=@idevento";

            try
            {
                  _connection.Open();
                using var command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@idevento", id);
                command.ExecuteNonQuery();

            }

            
             catch(MySqlException ex)
            {   
                Console.WriteLine($"Erro do Banco: + {ex.Message}");
            }

        catch(Exception ex)
            { 
                Console.WriteLine($"Erro Desconhecido: + {ex.Message}");
            }

        finally
            {   
                _connection.Close();
            }
        }
    
    }
}
