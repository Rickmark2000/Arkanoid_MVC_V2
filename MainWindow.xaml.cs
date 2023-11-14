
using Arkanoid_MVC.Modelos.Modelos;
using System.Windows;


namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            Title = "Menu principal";
            empezar.Content = "Empezar partida";
            salir.Content = "Salir";
            score.Content = "Score Board";
        
        }

        public void empezar_partida(object sender, RoutedEventArgs e)
        {
            Usuarios u = new Usuarios(1, "ewqeq", "dsadsa", "dsadsa", "ewqe");
            Juego_arkanoid juego = new Juego_arkanoid(u);
            juego.Show();
            this.Close();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void score_Click(object sender, RoutedEventArgs e)
        {
            ScoreWindow score = new ScoreWindow();
            score.Show();

        }
    }
}
