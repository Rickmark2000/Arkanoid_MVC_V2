
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
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Vista;
using Arkanoid_MVC.Controladores.Interfaces.Controles;
using Arkanoid_MVC.Controladores.Crear_elementos_juego.Crear_Figuras;
using Arkanoid_MVC.Modelos.Enumeraciones;
using Arkanoid_MVC.Controladores.Interfaces.Diseño_Canvas;
using Arkanoid_MVC.Controladores.Crear_elementos_juego.Diseños.Diseño_Figuras;
using System.Windows.Media.Media3D;

namespace Arkanoid_MVC
{
    public partial class Juego_arkanoid : Window
    {

        private DispatcherTimer timer;
        private int puntuacion_actual = 0;
        private IPartida<Rectangle> partida;
        private IControles<Rectangle> controles;
        private Conexiones conexiones;
        private FiguraSinVelocidad bloque;
        private FiguraVelocidad bola, plataforma;

        public Juego_arkanoid(Conexiones conexion)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.conexiones = conexion;

            preparar_partida();

            iniciar_partida();

        }

        private void preparar_partida()
        {
            Random random = new Random();
            IFactory<Figura> factory = new FactoryFigura();
            ICrearFiguras<FiguraSinVelocidad> figuraSinVelocidad = new CrearFiguraSinVelocidad();
            ICrearFiguras<FiguraVelocidad> figuraVelocidad = new CrearFiguraVelocidad();

            plataforma = figuraVelocidad.crear(160, 20, Width/2, Height-60, ETipoFigura.Velocidad);
            bloque = figuraSinVelocidad.crear(110,30, 26, 44, ETipoFigura.SinVelocidad);
            bola = figuraVelocidad.crear(35, Width/2, Height/2, ETipoFigura.Velocidad);

            bloque.num = random.Next(4, 20);
            plataforma.velocidad = 5.3f;
            bola.velocidad = 2.8f;
        }

        private void iniciar_partida()
        {
            controles = new ControlesJugador(ventana, plataforma.velocidad);
            partida = new Partida(bola, bloque, plataforma);
            partida.prepararJuego(Width, Height, CanvasJuego);
            partida.Guardar_posiciones_iniciales();

            Iniciar_timer();
        }

        private void Iniciar_timer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(0.6);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            partida.actualizar_pos();
            partida.actualizar_posJugador(controles, ref CanvasJuego);
            partida.actualizar_colisiones(ref CanvasJuego, ref puntuacion_actual);

            txtScore.Content = "Puntuación: " + puntuacion_actual;

            if (partida.gameOver())
            {
                partida.terminar_partida(timer, puntuacion_actual, conexiones);
                Menu_Principal menu = new Menu_Principal(conexiones);
                menu.Show();
                this.Close();
                
            }
        }
    }
}
