
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Controladores.Controles;
using Arkanoid_MVC.Controladores.Colisiones;
using Arkanoid_MVC.Controladores.Juego;
using Arkanoid_MVC.Controladores.Observer;
using Microsoft.VisualBasic;
using Arkanoid_MVC.Controladores.DB_Controller;
using System.Configuration;
using System.Collections.Generic;
using Arkanoid_MVC.Modelos.Repositorios;
using Arkanoid_MVC.Controladores.Partida_Manage;

namespace Arkanoid_MVC
{
    public partial class Juego_arkanoid : Window
    {
      
        private DispatcherTimer timer;
        private int score = 0;

        private IRepositorio<Usuarios> usuarios_repositorio;
        private Usuarios usuarioSesion;

        private Partida_Manage partida;

        private Controles_jugador controles;

        public Juego_arkanoid(Usuarios usuarioSesion)
        {
            InitializeComponent();
            this.usuarioSesion = usuarioSesion;
            controles = new Controles_jugador(ventana, 6);

            partida = new Partida_Manage(9);
            partida.prepararJuego(Width,Height,CanvasJuego);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (!partida.gameOver())
            {
                txtScore.Content = "Puntuación: " + score;

                partida.actualizar_posJugador(controles, ref CanvasJuego);
                partida.actualizar_posBola();
                partida.actualizar_colisiones(ref CanvasJuego, ref score);

            }
            else
            {
                timer.Stop();
                MessageBox.Show("Fin de partida. Puntuacion: "+score);
                string nombre_Jugador;
                do
                {
                    nombre_Jugador = Interaction.InputBox("El nombre tiene que tener un tamaño de 3", "Introducir nick", "Aqui el nombre");
                    
                } while (nombre_Jugador.Equals("")|| (nombre_Jugador.Length < 3 && nombre_Jugador.Length >3));
                MessageBox.Show($"Nick {nombre_Jugador} introducido");
                string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
                usuarios_repositorio = new UsuariosRepositorio<Usuarios>(connectionString);
                /*
                
                DB_Controller controller = new DB_Controller(connectionString);
                
                List<object> s = controller.recuperar_consulta(consulta);
                */
                MainWindow menu = new MainWindow();
                menu.Show();
                this.Close();
            }
        }
    }
}
