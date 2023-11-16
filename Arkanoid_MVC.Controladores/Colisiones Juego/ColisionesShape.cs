
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Controladores.Observer;
using Arkanoid_MVC.Modelos.Enumeraciones;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Colisiones
{
    public class ColisionesShape
    {
        private IObservarColision<Ellipse, Rectangle> observar = new ObservarColision();
        private ColisionInterseccion interseccion = new ColisionInterseccion();


        public void colisiona(Ellipse bola, ref double posX, ref double posY, ref Canvas element, ref bool gameOver)
        {
            IObservarColision<Ellipse, Rectangle> observar = new ObservarColision();
            ETipoColision tipo = observar.estado(bola, element);

            switch (tipo)
            {
                case ETipoColision.ColisionHorizontal:
                    posX *= -1;
                    break;
                case ETipoColision.ColisionVertical:
                    posY *= -1;
                    break;
                case ETipoColision.fuera:
                    gameOver = true;
                    break;
            }
        }

        public void colisiona(Ellipse bola, ref double posX, ref double posY, Rectangle plataforma)
        {

            ETipoColision tipo = observar.estado(bola, plataforma);

            switch (tipo)
            {
                case ETipoColision.EnPlataforma:
                    interseccion.Colision_interseccionY(bola, plataforma, ref posY);

                    break;

            }
        }

        public void colisiona(Ellipse bola, ref double posX, ref double posY, ref int score, ref Canvas element, IManagement<Rectangle> bloques)
        {
            ColisionBloque colisionBloque = new ColisionBloque();
            Rectangle bloque = colisionBloque.Colision_Bloque(bloques, element, bola);

            if (bloque != null)
            {
                score++;
                interseccion.Colision_interseccionY(bola, bloque, ref posY);
                interseccion.Colision_interseccionX(bola, bloque, ref posX);
            }
        }

    }
}
