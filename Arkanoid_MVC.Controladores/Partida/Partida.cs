using Arkanoid_MVC.Controladores.Colisiones;
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.ControladoresDB;
using Arkanoid_MVC.Controladores.Controles;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Controladores.Juego;
using Arkanoid_MVC.Modelos.Enum;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Arkanoid_MVC.Controladores.Partida_Manage
{
    public class Partida
    {
        private CrearFiguras crear = new CrearFiguras();
        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private IManagement<Rectangle> bloques;
        private double BolaInicialX, BolaInicialY, PlataformaInicialX,actualBolaX, actualBolaY;
        private int num_bolas;
        private bool isGameOver;

        public Partida(int num_bolas, float actualizar_pos_bola)
        {
            this.num_bolas = num_bolas;
            this.actualBolaX = actualizar_pos_bola;
            this.actualBolaY = actualizar_pos_bola;
        }


        public void prepararJuego(double Width, double Height,Canvas CanvasJuego)
        {
            bola = crear.crear_bola(Width, Height, CanvasJuego);
            plataforma_jugador = crear.crear_plataforma(Width, Height, CanvasJuego);
            bloques = crear.crear_bloques(num_bolas, CanvasJuego, Width);
        }

        public void Guardar_posiciones_iniciales()
        {
            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }

        public void actualizar_colisiones(ref Canvas CanvasJuego,ref int puntuacion_actual)
        {
            ColisionesShape colision = new ColisionesShape();
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref CanvasJuego, ref isGameOver);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref puntuacion_actual, ref CanvasJuego, bloques);
        }

        public void actualizar_posBola()
        { 
            Canvas.SetTop(bola, BolaInicialY += actualBolaY);
            Canvas.SetLeft(bola, BolaInicialX += actualBolaX);
        }

        public bool gameOver()
        {
            if(!isGameOver && bloques.ObtenerBloques().Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void actualizar_posJugador(ControlesJugador controles,ref Canvas CanvasJuego)
        {
            Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
            controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);
        }

        public void terminar_partida(DispatcherTimer timer, int score, Usuarios usuarioSesion)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
            Conexiones conexion = new Conexiones(connectionString);
            timer.Stop();
            MessageBox.Show("Fin de partida. Puntuacion: " + score);
            string nombre_Jugador;
            do
            {
                nombre_Jugador = Interaction.InputBox("El nombre tiene que tener un tamaño de 3", "Introducir nick", "Aqui el nombre");

            } while (nombre_Jugador.Equals("") || (nombre_Jugador.Length < 3 && nombre_Jugador.Length > 3));
            MessageBox.Show($"Nick {nombre_Jugador} valido");

        }
    }
}
