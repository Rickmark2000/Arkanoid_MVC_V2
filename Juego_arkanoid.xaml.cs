
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

namespace Arkanoid_MVC
{
    public partial class Juego_arkanoid : Window
    {
        private bool isGameOver;
        private DispatcherTimer timer;

        private double BolaInicialX, BolaInicialY, PlataformaInicialX;
        double actualBolaX = 2, actualBolaY = 2;
        private int score = 0;

        private Crear_figuras juego = new Crear_figuras();

        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private Ifiguras_management<Rectangle> bloques;

        private IObservador_colision<Ellipse, Rectangle> comprobarColisiones = new ObservarColision();
        private IRepositorio<Jugadores> jugador_Repositorio;
        private IRepositorio<Puntuaciones> puntuacion_repositorio;
        private IRepositorio<Usuarios> usuarios_repositorio;
        private Usuarios usuarioSesion;

        private Controles_jugador controles;


        private ColisionAplicar colision = new ColisionAplicar();

        public Juego_arkanoid(Usuarios usuarioSesion)
        {
            InitializeComponent();
            this.usuarioSesion = usuarioSesion;
            controles = new Controles_jugador(ventana, 6);

            prepararJuego();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(6);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void prepararJuego()
        {
            bola = juego.crear_bola(Width, Height, CanvasJuego);
            plataforma_jugador = juego.crear_plataforma(Width, Height, CanvasJuego);
            bloques = juego.crear_bloques(9, CanvasJuego, Width);

            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (!isGameOver && bloques.ObtenerBloques().Count>0)
            {
                Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
                controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);


                Canvas.SetTop(bola, BolaInicialY += actualBolaY);
                Canvas.SetLeft(bola, BolaInicialX += actualBolaX);

                txtScore.Content = "Puntuación: " +score;

                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, CanvasJuego, ref isGameOver);
                colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref score,CanvasJuego, bloques);

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
