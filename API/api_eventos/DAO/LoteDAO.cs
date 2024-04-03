using System;
using System.Collections.Generic;
using System.Linq;
using api_eventos.Models;
using api_eventos.Repository;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api_eventos.DAO
{
    public class LoteDAO
    {
        private MySqlConnection _connection;

        public LoteDAO()
            {
                _connection = MySqlConnectionFactory.GetConnection();
            }

            public List<Lote> GetAll()
            {
                List<Lote> lotes= new List<Lote>();
                string query = "SELECT * FROM lote";


                try
                {
                    _connection.Open();
                    MySqlCommand command = new MySqlCommand(query, _connection);
                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Lote lote =new Lote();
                            lote.idlote = reader.GetInt32("idlote");
                            lote.Descricao = reader.GetString("descricao");
                            lote.ValorUnitario = reader.GetDouble("valor_unitario");
                            lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                            lote.Saldo = reader.GetInt32("saldo");
                            lote.Ativo = reader.GetBoolean("ativo");
                            lote.IdEvento = reader.GetInt32("evento_idevento");
                            lotes.Add(lote);
                        }
                    }
                }
                catch(MySqlException ex)
                {
                    //mapeando os erros do banco
                    Console.WriteLine($"Erro do BANCO: {ex.Message}");
                }
                catch(Exception ex)
                {
                    //mapenado os erros de forma geral
                    Console.WriteLine($"Erro Desconhecido {ex.Message}");
                }
                finally
                {
                    //fecha a conexão com o banco
                    _connection.Close();
                }

                return lotes;
            }

                public Lote GetId(int id)
                {
                    Lote lote = new Lote();
                    string query = $"SELECT * FROM lote WHERE idlote = {id}";
                    try 
                    {
                        _connection.Open();
                        MySqlCommand command = new MySqlCommand(query, _connection);
                        using(MySqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Lote lote1 =new Lote();
                                lote.idlote = reader.GetInt32("idlote");
                                lote.Descricao = reader.GetString("descricao");
                                lote.ValorUnitario = reader.GetDouble("valor_unitario");
                                lote.QuantidadeTotal = reader.GetInt32("quantidade_total");
                                lote.Saldo = reader.GetInt32("saldo");
                                lote.Ativo = reader.GetBoolean("ativo");
                                lote.IdEvento = reader.GetInt32("evento_idevento");
                                
                               
                                
                            }
                        }
                    }
                    catch(MySqlException ex)
                    {
                        Console.WriteLine($"Erro no Banco: {ex.Message}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Erro Desconhecido: {ex.Message}");
                    }
                    finally
                    {
                        _connection.Close();
                    }
                    return lote;
                }

                public void CriarLote(Lote lote)
                {
                    string query = "INSERT INTO lote (descricao,valor_unitario,quantidade_total,saldo,ativo,evento_idevento ) VALUES (@Descricao,@ValorUnitario, @QuantidadeTotal, @Saldo, @Ativo, @IdEvento)";
                    


                    try
                    {
                        _connection.Open();
                        using(var command = new MySqlCommand(query, _connection))
                        {
                            command.Parameters.AddWithValue("@Descricao", lote.Descricao);
                            command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                            command.Parameters.AddWithValue("@QuantidadeTotal", lote.QuantidadeTotal);
                            command.Parameters.AddWithValue("@saldo", lote.Saldo);
                            command.Parameters.AddWithValue("@Ativo", lote.Ativo);
                            command.Parameters.AddWithValue("@IdEvento", lote.IdEvento);
                            
                          
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

            public void AtualizarLote(int id, Lote lote)
            {
                string query = "UPDATE lote SET " +
                                " descricao=@Descricao, " +
                                " valor_unitario=@ValorUnitario, " +
                                " quantidade_total=@QuantidadeTotal, " +
                                " saldo=@Saldo, " +  
                                "ativo=@Ativo, " +
                                "evento_idevento= @IdEvento " +
                                "WHERE idlote=@idlote"
                                 ;
                        

                try
                {
                   
                   _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                        
                    {       command.Parameters.AddWithValue("@idlote", id);
                            command.Parameters.AddWithValue("@Descricao", lote.Descricao);
                            command.Parameters.AddWithValue("@ValorUnitario", lote.ValorUnitario);
                            command.Parameters.AddWithValue("@QuantidadeTotal", lote.QuantidadeTotal);
                            command.Parameters.AddWithValue("@Saldo", lote.Saldo);
                            command.Parameters.AddWithValue("@Ativo", lote.Ativo);
                            command.Parameters.AddWithValue("@IdEvento", lote.IdEvento);

                            command.ExecuteNonQuery();
                    }
                }
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }

            public void DeletarLote (int id)
            {
                string query = "DELETE FROM lote WHERE idlote = @idlote";

                try 
                {
                    _connection.Open();
                    using(var command = new MySqlCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@idlote", id);
                        command.ExecuteNonQuery();
                    }
                }
                
                catch(MySqlException ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                catch(Exception ex)
                {
                     Console.WriteLine($"Erro de Banco: {ex.Message}");
                }
                finally
                {
                    _connection.Close();
                }
            }

    }
}


