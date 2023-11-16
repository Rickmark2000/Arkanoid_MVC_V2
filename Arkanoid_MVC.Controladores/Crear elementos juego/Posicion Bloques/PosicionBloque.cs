using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Crear_elementos_juego.Posicion_Bloques
{
    public class PosicionBloque
    {


        public Canvas posicionar_bloques(int num_bloques, Canvas canvas_juego, double with, Figura figuraBloque, IManagement<Rectangle> bloquesManagement, IImplementarShape<Rectangle> implementar)
        {
            Rectangle[] bloques = new Rectangle[num_bloques];
            int separacionX = 11;
            int separacionY = 11;
            double tamano_total = 0;

            for (int i = 0; i < bloques.Length; i++)
            {
                if (tamano_total + figuraBloque.ancho > with)
                {
                    tamano_total = 0;
                    figuraBloque.posicionX = 26;
                    figuraBloque.posicionY += figuraBloque.alto + separacionY;
                }
                bloquesManagement.anadir(implementar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2));
                tamano_total += figuraBloque.ancho + separacionX;
                figuraBloque.posicionX += separacionX + figuraBloque.ancho;
            }

            return canvas_juego;
        }
    }
}
