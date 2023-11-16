using Arkanoid_MVC.Controladores.Colisiones;
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.ControladoresDB;
using Arkanoid_MVC.Controladores.Controles;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Controladores.Interfaces.Controles;
using Arkanoid_MVC.Controladores.Juego;
using Arkanoid_MVC.Modelos.Enumeraciones;
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
    public class Partida : IPartida<Rectangle>
    {
        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private IManagement<Rectangle> bloques;
        private Figura figuraBola, figuraPlataforma, figuraBloque;
        private double BolaInicialX, BolaInicialY, PlataformaInicialX, actualBolaX, actualBolaY;
        private int num_bloques;
        private bool isGameOver;

        public Partida(FiguraVelocidad bola, FiguraSinVelocidad bloque, FiguraVelocidad plataforma)
        {
            this.num_bloques = bloque.num;
            this.actualBolaX = bola.velocidad;
            this.actualBolaY = bola.velocidad;
            this.figuraBloque = bloque;
            this.figuraBola = bola;
            this.figuraPlataforma = plataforma;
        }


        public void prepararJuego(double Width,Canvas CanvasJuego)
        {
            CrearShape crear = new CrearShape();
            bola = crear.crear_bola(CanvasJuego, figuraBola);
            plataforma_jugador = crear.crear_plataforma(CanvasJuego, figuraPlataforma);
            bloques = crear.crear_bloques(num_bloques, CanvasJuego, Width, figuraBloque);
        }

        public void Guardar_posiciones_iniciales()
        {
            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }

        public void actualizar_colisiones(ref Canvas CanvasJuego, ref int puntuacion_actual)
        {
            ColisionesShape colision = new ColisionesShape();
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref CanvasJuego, ref isGameOver);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref puntuacion_actual, ref CanvasJuego, bloques);
        }

        public void actualizar_pos()
        {
            Canvas.SetTop(bola, BolaInicialY += actualBolaY);
            Canvas.SetLeft(bola, BolaInicialX += actualBolaX);
        }

        public bool gameOver()
        {
            if (!isGameOver && bloques.ObtenerBloques().Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void actualizar_posJugador(IControles<Rectangle> controles, ref Canvas CanvasJuego)
        {
            Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
            controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);
        }

        public void terminar_partida(DispatcherTimer timer, int score, Conexiones conexion)
        {
            timer.Stop();
            MessageBox.Show("Fin de partida. Puntuacion: " + score);
            string nombre_Jugador;
            do
            {
                nombre_Jugador = Interaction.InputBox("El nombre tiene que tener un tamaño de 3", "Introducir nick", "Aqui el nombre");

            } while (nombre_Jugador.Equals("") || (nombre_Jugador.Length < 3 || nombre_Jugador.Length > 3));

            registrar_jugador(score, conexion, nombre_Jugador);

            MessageBox.Show($"Nick {nombre_Jugador} valido");

        }

        private static void registrar_jugador(int score, Conexiones conexion, string nombre_Jugador)
        {
            Controlador<Jugadores> controladorJugadores = new ControladorJugadores(conexion);
            Controlador<Puntuaciones> controladorPuntuaciones = new ControladorPuntuaciones(conexion);

            Jugadores jugador = new Jugadores(conexion.idSesion, score, nombre_Jugador, 3);

            controladorJugadores.registrar(jugador);

            Puntuaciones puntuaciones = new Puntuaciones(jugador.id, score, score);

            controladorPuntuaciones.registrar(puntuaciones);
        }
    }
}
