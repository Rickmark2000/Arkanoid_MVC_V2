using Arkanoid_MVC.Controladores.Diseño_Figuras;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Controladores.Management;
using Arkanoid_MVC.Modelos.Enumeraciones;
using Arkanoid_MVC.Modelos.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Juego
{
    public class CrearShape
    {
        private IEditarShape diseño;

        public Ellipse crear_bola(double with, double height, Canvas canvas_juego, Figura figuraBola)
        {
            figuraBola.posicionX = with / 2;
            figuraBola.posicionY = height / 2;
            diseño = new EditarElipse(figuraBola);
            return (Ellipse)diseño.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }

        public ManagementBloques crear_bloques(int num_bloques, Canvas canvas_juego, double with, Figura figuraBloque)
        {
            Rectangle[] bloques = new Rectangle[num_bloques];
            IManagement<Rectangle> bloquesManagement = new ManagementBloques();

            figuraBloque.ancho = 110;
            figuraBloque.alto = 30;
            figuraBloque.posicionX = 26;
            figuraBloque.posicionY = 44;

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

                diseño = new EditarRectangulo(figuraBloque);
                bloques[i] = (Rectangle)diseño.Implementar(ref canvas_juego, Colors.Aqua, Colors.Black, 2);
                bloquesManagement.anadir(bloques[i]);

                tamano_total += figuraBloque.ancho + separacionX;
                figuraBloque.posicionX += separacionX + figuraBloque.ancho;


            }

            return (ManagementBloques)bloquesManagement;
        }


        public Rectangle crear_plataforma(double with, double height, Canvas canvas_juego, Figura figuraPlataforma)
        {
            figuraPlataforma.ancho = 160;
            figuraPlataforma.alto = 20;
            figuraPlataforma.posicionX = with / 2;
            figuraPlataforma.posicionY = height - 60;
            diseño = new EditarRectangulo(figuraPlataforma);
            return (Rectangle)diseño.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }
    }
}
