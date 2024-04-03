using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_eventos.DAO
{
    public class EventosClass
    {
        public static EventosClass GetConnection()
        {
            string connectionString = "Server=localhost;Database=bd_herois;Uid=root;Pwd=senai2024;";
            EventosClass connection = new EventosClass();
            return connection;
        }
    }
}