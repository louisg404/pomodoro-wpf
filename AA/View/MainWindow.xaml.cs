using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using pomodoro.Model.DAL;
using MySql.Data.MySqlClient;

namespace pomodoro
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerTravail;
        DispatcherTimer timerPause;
        TimeSpan time;
        TimeSpan timeTemp;        

        string compteur = "";
        int indicateur = 0;
        public int pomodoro = 0;
        public string pseudo = "";

        // Renseigner temps souhaités (en secondes)
        int travailDuree = 10;
        int pauseDuree = 5;
        int pauseLongueDuree = 15;

        public MainWindow(string text)
        {
            InitializeComponent();
            Console.WriteLine(text);

            time = TimeSpan.FromSeconds(travailDuree);

            TextPause.Visibility = Visibility.Hidden;
            Start2.Visibility = Visibility.Hidden;
            Pause2.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Hidden;

            pseudo = text;
        }

        // Déconnexion
        private void Button_Click_Deco(object sender, RoutedEventArgs e)
        {

            View.connexion_inscription co_inscr = new View.connexion_inscription();
            co_inscr.Show();
            this.Close();
        }

        // Démarrer phase de travail
        public void start_click(object sender, EventArgs e)
        {
            if (time != TimeSpan.FromSeconds(travailDuree))
            {
                // Reprendre
                time = timeTemp;
            }
            else
            {
                time = TimeSpan.FromSeconds(travailDuree);
            }

            TravailSum.Visibility = Visibility.Hidden;
            TextPause.Visibility = Visibility.Hidden;
            Start2.Visibility = Visibility.Hidden;
            Pause2.Visibility = Visibility.Hidden;

            timerTravail = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Timer.Content = time.ToString("c");
                timerTravail.Start();

                if (time == TimeSpan.Zero)
                {
                    timerTravail.Stop();

                    TextTravail.Visibility = Visibility.Hidden;
                    Start.Visibility = Visibility.Hidden;
                    Pause.Visibility = Visibility.Hidden;

                    TextPause.Visibility = Visibility.Visible;
                    Start2.Visibility = Visibility.Visible;
                    Pause2.Visibility = Visibility.Visible;

                    compteur = compteur + "Trav. ";
                    Compteur.Text = compteur;

                    indicateur++;
                    if (indicateur < travailDuree)
                    {
                        time = TimeSpan.FromSeconds(pauseDuree);
                    }
                    else
                    {
                        time = TimeSpan.FromSeconds(pauseLongueDuree);
                    }
                }
                else
                {
                    time = time.Add(TimeSpan.FromSeconds(-1));
                }

            }, Application.Current.Dispatcher);
        }

        // Bouton pause pendant phase de travail
        public void pause_click(object sender, EventArgs e)
        {
            timerTravail.Stop();
            // Attribuer valeur courante pour fonctionnalité 'Reprendre'
            timeTemp = time;
        }

        // Démarrer phase de pause
        public void start_click2(object sender, EventArgs e)
        {
            if (indicateur < travailDuree)
            {
                if (time != TimeSpan.FromSeconds(pauseDuree))
                {
                    // Reprendre
                    time = timeTemp;
                }
                else
                {
                    time = TimeSpan.FromSeconds(pauseDuree);
                }

                TextTravail.Visibility = Visibility.Hidden;
                Start.Visibility = Visibility.Hidden;
                Pause.Visibility = Visibility.Hidden;

                timerPause = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    Timer.Content = time.ToString("c");
                    timerPause.Start();

                    if (time == TimeSpan.Zero)
                    {
                        timerPause.Stop();

                        TextPause.Visibility = Visibility.Hidden;
                        Start2.Visibility = Visibility.Hidden;
                        Pause2.Visibility = Visibility.Hidden;

                        TextTravail.Visibility = Visibility.Visible;
                        Start.Visibility = Visibility.Visible;
                        Pause.Visibility = Visibility.Visible;

                        compteur = compteur + "Pause ";
                        Compteur.Text = compteur;

                        time = TimeSpan.FromSeconds(travailDuree);
                    }
                    else
                    {
                        time = time.Add(TimeSpan.FromSeconds(-1));
                    }

                }, Application.Current.Dispatcher);
            }
            // Pause plus longue (après 4 phases de travail)
            else
            {
                if (time != TimeSpan.FromSeconds(pauseLongueDuree))
                {
                    // Reprendre
                    time = timeTemp;
                }
                else
                {
                    time = TimeSpan.FromSeconds(pauseLongueDuree);
                }

                TextTravail.Visibility = Visibility.Hidden;
                Start.Visibility = Visibility.Hidden;
                Pause.Visibility = Visibility.Hidden;

                timerPause = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    Timer.Content = time.ToString("c");
                    timerPause.Start();

                    if (time == TimeSpan.Zero)
                    {
                        timerPause.Stop();

                        TextPause.Visibility = Visibility.Hidden;
                        Start2.Visibility = Visibility.Hidden;
                        Pause2.Visibility = Visibility.Hidden;

                        TextTravail.Visibility = Visibility.Visible;
                        Start.Visibility = Visibility.Visible;
                        Pause.Visibility = Visibility.Visible;

                        compteur = compteur + "\n";
                        pomodoro++;
                        Save.Visibility = Visibility.Visible;
                        Info.Visibility = Visibility.Hidden;

                        Compteur.Text = compteur;
                        indicateur = 0;

                        time = TimeSpan.FromSeconds(travailDuree);
                    }
                    else
                    {
                        time = time.Add(TimeSpan.FromSeconds(-1));
                    }

                }, Application.Current.Dispatcher);
            }
        }

        // Bouton pause pendant phase de pause
        public void pause_click2(object sender, EventArgs e)
        {
            timerPause.Stop();
            // Attribuer valeur courante pour fonctionnalité 'Reprendre'
            timeTemp = time;
        }

        // Bouton sauvegarder
        public void save(object sender, EventArgs e)
        {
            try
            {
                ConnectionBdd bdd = new ConnectionBdd();
                MySqlConnection connection = bdd.getConnection();

                // Création d'une commande SQL en fonction de l'objet connexion
                MySqlCommand cmd = connection.CreateCommand();

                // Récupérer id du client connecté
                cmd.CommandText = "SELECT id from client where pseudo='" + pseudo + "'";

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();
                int Id = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine(Id);

                // Insertion du client et du nombre de cycles pomodoro
                cmd.CommandText = "INSERT INTO historique (user_id, pomodoro) VALUES (" + Id + ", " + pomodoro + ")";

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                connection.Close();

                Save.Visibility = Visibility.Hidden;
                Info.Visibility = Visibility.Visible;
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
            }
        }
    }
}
