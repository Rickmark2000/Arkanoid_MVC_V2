using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Observer
{
    public class ObservarColision : IObservarColision<Ellipse,Rectangle>
    {


        public ETipoColision estado(Ellipse figura, Canvas element)
        {
            ETipoColision estado = ETipoColision.nada;

            if (!detectar_fuera_limite(figura, element))
            {
                if (detectar_colision_muro(figura, element))
                {
                    estado = ETipoColision.ColisionHorizontal;
                }
                else if (detectar_colision_techo(figura))
                {
                    estado = ETipoColision.ColisionVertical;
                }
            }
            else
            {
                estado = ETipoColision.fuera;
            }


            return estado;
        }

        public ETipoColision estado(Ellipse figura, Rectangle plataforma)
        {
            ETipoColision tipo = ETipoColision.nada;

            if(detectar_colision_plataforma(figura, plataforma))
            {
                tipo = ETipoColision.EnPlataforma;
            }
            else
            {
                tipo = ETipoColision.nada;
            }
            return tipo;
            
        }

        private bool detectar_colision_techo(Ellipse ball)
        {

            if (Canvas.GetTop(ball) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool detectar_colision_muro(Ellipse ball, Canvas CanvasJuego)
        {
            if (Canvas.GetLeft(ball) + ball.Width > CanvasJuego.Width || Canvas.GetLeft(ball) < 0)
            {
                return true;

            }
            else { return false; }
        }
        

        private  bool detectar_fuera_limite(Ellipse ball, Canvas element)
        {
            if (Canvas.GetTop(ball) + ball.Height >= (Math.Abs(element.Height + ball.Height)))
            {

                return true;

            }
            else
            {
                return false;
            }
        }

        public bool detectar_colision_plataforma(Ellipse ball, Rectangle plataforma)
        {

            Rect sd = new Rect(Canvas.GetLeft(plataforma), Canvas.GetTop(plataforma), plataforma.Width, plataforma.Height);
            Rect SD2 = new Rect(Canvas.GetLeft(ball), Canvas.GetTop(ball), ball.Width, ball.Height);
            bool colisiona = sd.IntersectsWith(SD2) == true ? true : false;
            return colisiona;

        }

    }
}
