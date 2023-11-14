
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Configuration;
using System.Windows;


namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {
        private Usuarios usuario = new Usuarios(2, "Carlos", "Castro", "carl@outlook.com", "Mark");
        private string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
        private string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        private Conexiones conexion;

        public MainWindow()
        {

            InitializeComponent();
            conexion = new Conexiones(connectionString,proyectoRaiz);
            Title = "Menu principal";
            empezar.Content = "Empezar partida";
            salir.Content = "Salir";
            score.Content = "Score Board";
        
        }

        public void empezar_partida(object sender, RoutedEventArgs e)
        {
            int num_bolas = 9;
            float velocidad_jugador = 5.3f;
            float velocidad_bola = 2.8f;
            Juego_arkanoid juego = new Juego_arkanoid(usuario,num_bolas,velocidad_jugador,velocidad_bola,conexion);
            juego.Show();
            this.Close();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void score_Click(object sender, RoutedEventArgs e)
        {
            
            ScoreWindow score = new ScoreWindow(usuario, conexion);
            score.Show();

        }
    }
}
