using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace api_eventos.Repository
{
    public class MySqlConnectionFactory
    {
<<<<<<< HEAD
        
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_eventos_senailp;Uid=root;Pwd=senai2024;";
=======
         public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_eventos_senailp;Uid=root;Pwd=Lara@1603;";
>>>>>>> 9d9729f5f3520e03ed5d70582011149b0179b639
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}