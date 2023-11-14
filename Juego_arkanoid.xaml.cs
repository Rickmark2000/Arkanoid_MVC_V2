
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

namespace Arkanoid_MVC
{
    public partial class Juego_arkanoid : Window
    {

        private DispatcherTimer timer;
        private int puntuacion_actual = 0;
        private Usuarios usuarioSesion;
        private Partida partida;
        private ControlesJugador controles;
        private AccionesRepositorios conexionRepositorio;
        private Conexiones conexiones;

        public Juego_arkanoid(Usuarios usuarioSesion,int num_bolas,float velocidad_jugador,float velocidad_bola, Conexiones conexion)
        {
            InitializeComponent();
            this.conexiones = conexion;
            this.usuarioSesion = usuarioSesion;
            controles = new ControlesJugador(ventana, velocidad_jugador);
            partida = new Partida(num_bolas,velocidad_bola);
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
            partida.actualizar_posBola();
            partida.actualizar_posJugador(controles, ref CanvasJuego);
            partida.actualizar_colisiones(ref CanvasJuego, ref puntuacion_actual);

            txtScore.Content = "Puntuación: " + puntuacion_actual;

            if (partida.gameOver())
            {
                partida.terminar_partida(timer, puntuacion_actual, usuarioSesion);
                Menu_Principal menu = new Menu_Principal(usuarioSesion,conexiones);
                    menu.Show();
                    this.Close();
                
            }
        }
    }
}
