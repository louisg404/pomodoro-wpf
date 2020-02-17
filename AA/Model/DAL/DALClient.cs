using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace pomodoro.Model.DAL
{
    class DALClient
    {
        public void getClient(ObservableCollection<ViewModel.ClientBinder> Actifclient, ObservableCollection<ViewModel.ClientBinder> Actifadmin,string pseudo, string password)
        { 
            ConnectionBdd bdd = new ConnectionBdd();
            MySqlConnection connection = bdd.getConnection();
            MySqlCommand cmd = connection.CreateCommand();

            // Requête SQL            
            cmd.CommandText = "SELECT * from client where pseudo=@pseudo AND password=@password";
            cmd.Parameters.AddWithValue("@pseudo", pseudo);
            cmd.Parameters.AddWithValue("@password", password);
            
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                 {
                    //redirection user exist
                    int Id = reader.GetInt32(0);
                    string NomProperty = reader.GetString(1);
                    string PrenomProperty = reader.GetString(2);
                    string PseudoProperty = reader.GetString(3);
                    string MailProperty = reader.GetString(4);
                    string PasswordProperty = reader.GetString(5);
                    int AdminProperty = reader.GetInt32(6);
                    if(AdminProperty == 1)
                    {
                        ViewModel.ClientBinder recupclient = new ViewModel.ClientBinder(Id, NomProperty, PrenomProperty, PseudoProperty, MailProperty, PasswordProperty, AdminProperty);
                        Actifadmin.Add(recupclient);
                    }
                    else
                    {
                        ViewModel.ClientBinder recupclient = new ViewModel.ClientBinder(Id, NomProperty, PrenomProperty, PseudoProperty, MailProperty, PasswordProperty, AdminProperty);
                        Actifclient.Add(recupclient);
                    }
                }
            }
              
            reader.Close();
            connection.Close();
        }

        public void AddClient(ObservableCollection<ViewModel.ClientBinder> UserExist,string nom, string prenom, string pseudo, string mail, string password)
        {
            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();

                // Ouverture de la connexion SQL
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * from client where pseudo=@pseudo or mail=@mail";
                cmd.Parameters.AddWithValue("@pseudo", pseudo);
                cmd.Parameters.AddWithValue("@mail", mail);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //redirection user exist
                        int Id = reader.GetInt32(0);
                        string NomProperty = reader.GetString(1);
                        string PrenomProperty = reader.GetString(2);
                        string PseudoProperty = reader.GetString(3);
                        string MailProperty = reader.GetString(4);
                        string PasswordProperty = reader.GetString(5);
                        int AdminProperty = reader.GetInt32(6);
                        ViewModel.ClientBinder recupclient = new ViewModel.ClientBinder(Id, NomProperty, PrenomProperty, PseudoProperty, MailProperty, PasswordProperty, AdminProperty);
                        UserExist.Add(recupclient);
                    }
                }
                else
                {
                    connection.Close();
                    ConnectionBdd bdd2 = new ConnectionBdd();
                    MySqlConnection connection2 = bdd2.getConnection();
                    MySqlCommand insert = connection2.CreateCommand();

                    insert.CommandText = "INSERT INTO client (nom,prenom,mail,pseudo,password) VALUES (@nom,@prenom,@mail,@pseudo,@password)";

                    insert.Parameters.AddWithValue("@nom", nom);
                    insert.Parameters.AddWithValue("@prenom", prenom);
                    insert.Parameters.AddWithValue("@mail", mail);
                    insert.Parameters.AddWithValue("@pseudo", pseudo);
                    insert.Parameters.AddWithValue("@password", password);

                    // Exécution de la commande SQL
                    insert.ExecuteNonQuery();

                    // Fermeture de la connexion
                    connection2.Close();
                }
                // Création d'une commande SQL en fonction de l'objet connexion
                connection.Close();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Impossible de se connecter au serveur");
                        break;
                    case 1045:
                        MessageBox.Show("Utilisateur ou mot de passe invalide");
                        break;
                }
                // Gestion des erreurs :
                // Possibilité de créer un Logger pour les exceptions SQL reçus
                // Possibilité de créer une méthode avec un booléan en retour pour savoir si le contact à été ajouté correctement.

            }
        }
    }
}
