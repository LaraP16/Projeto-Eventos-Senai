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
            Evento evento = null;
            string query = $"SELECT * FROM evento WHERE idevento = {id};";

            try
            {
                _connection.Open();
                MySqlCommand command = new MySqlCommand(query, _connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        evento = new Evento();
                        evento.IdEvento = reader.GetInt32("idevento");
                        evento.Descricao = reader.GetString("descricao");
                        evento.TotalIngresso = reader.GetDecimal("total_ingresso");
                        evento.DataEvento = reader.GetDateTime("data_evento");
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

            return evento;
        }

        public void CreateEvento(Evento evento)
        {
            string query = "INSERT INTO evento (descricao, total_ingresso, data_evento) VALUES (@Descricao, @TotalIngresso, @DataEvento)";

            try
            {
                _connection.Open();
                using (var command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Descricao", evento.Descricao);
                    command.Parameters.AddWithValue("@TotalIngresso", evento.TotalIngresso);
                    command.Parameters.AddWithValue("@DataEvento", evento.DataEvento);

                    command.ExecuteNonQuery();
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
        }

        public void UpdateEvento(int id, Evento evento)
        {
            // Implementação da atualização do evento
        }

        public void DeleteEvento(int id)
        {
            // Implementação da exclusão do evento
        }
    }
}
