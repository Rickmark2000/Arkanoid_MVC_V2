
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
        private Usuarios usuarioSesion;
        private Partida partida;
        private ControlesJugador controles;

        public Juego_arkanoid(Usuarios usuarioSesion)
        {
            InitializeComponent();
            this.usuarioSesion = usuarioSesion;
            controles = new ControlesJugador(ventana, 9);
            partida = new Partida(9);
            partida.prepararJuego(Width, Height, CanvasJuego);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(15.2);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            partida.actualizar_posBola();
            partida.actualizar_posJugador(controles, ref CanvasJuego);
            partida.actualizar_colisiones(ref CanvasJuego, ref score);

            txtScore.Content = "Puntuación: " + score;

            if (partida.gameOver())
            {
                partida.terminar_partida(timer, score, usuarioSesion);
                MainWindow menu = new MainWindow();
                menu.Show();
                this.Close();
            }
        }
    }
}
