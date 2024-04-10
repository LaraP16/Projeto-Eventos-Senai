using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api_eventos.Repository
{
    public class MySqlConnectionFactory
    {
         public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_eventos_senailp;Uid=root;Pwd=Lara@1603;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}