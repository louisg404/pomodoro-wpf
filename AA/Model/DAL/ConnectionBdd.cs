using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace pomodoro.Model.DAL
{
    public class ConnectionBdd
    {
        private MySqlConnection connection;

        // Méthode pour initialiser la connexion
        public ConnectionBdd()
        {
            string connectionString = "SERVER=localhost; DATABASE=projetcs; UID=root; PASSWORD=root";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
         public MySqlConnection getConnection()
         {
            return connection;
         }
    }
}
