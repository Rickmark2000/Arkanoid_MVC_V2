﻿using Arkanoid_MVC.Controladores.Colisiones;
using Arkanoid_MVC.Controladores.Controles;
using Arkanoid_MVC.Controladores.Juego;
using Arkanoid_MVC.Modelos.Enum;
using Arkanoid_MVC.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Partida_Manage
{
    public class Partida_Manage
    {
        private Crear_figuras crear = new Crear_figuras();
        private Rectangle plataforma_jugador;
        private Ellipse bola;
        private Ifiguras_management<Rectangle> bloques;
        private double BolaInicialX, BolaInicialY, PlataformaInicialX,actualBolaX = 2, actualBolaY = 2;
        private int num_bolas;
        private bool isGameOver;

        public Partida_Manage(int num_bolas)
        {
            this.num_bolas = num_bolas;
        }


        public void prepararJuego(double Width, double Height,Canvas CanvasJuego)
        {
            bola = crear.crear_bola(Width, Height, CanvasJuego);
            plataforma_jugador = crear.crear_plataforma(Width, Height, CanvasJuego);
            bloques = crear.crear_bloques(num_bolas, CanvasJuego, Width);

            BolaInicialY = Canvas.GetTop(bola);
            BolaInicialX = Canvas.GetLeft(bola);

            PlataformaInicialX = Canvas.GetLeft(plataforma_jugador);
        }

        public void actualizar_colisiones(ref Canvas CanvasJuego,ref int puntuacion_actual)
        {
            ColisionAplicar colision = new ColisionAplicar();
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, plataforma_jugador);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, CanvasJuego, ref isGameOver);
            colision.colisiona(bola, ref actualBolaX, ref actualBolaY, ref puntuacion_actual, CanvasJuego, bloques);
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

        public void actualizar_posJugador(Controles_jugador controles,ref Canvas CanvasJuego)
        {
            Canvas.SetLeft(plataforma_jugador, PlataformaInicialX);
            controles.mover(plataforma_jugador, ref PlataformaInicialX, CanvasJuego);
        }
    }
}