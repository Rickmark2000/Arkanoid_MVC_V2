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
        private IEditarShape editar;

        public Ellipse crear_bola(Canvas canvas_juego, Figura figuraBola)
        {
            editar = new EditarElipse(figuraBola);
            return (Ellipse)editar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }

        public IManagement<Rectangle> crear_bloques(int num_bloques, Canvas canvas_juego, double with, Figura figuraBloque)
        {
            Rectangle[] bloques = new Rectangle[num_bloques];
            IManagement<Rectangle> bloquesManagement = new ManagementBloques();

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

                editar = new EditarRectangulo(figuraBloque);
                bloques[i] = (Rectangle)editar.Implementar(ref canvas_juego, Colors.Aqua, Colors.Black, 2);
                bloquesManagement.anadir(bloques[i]);

                tamano_total += figuraBloque.ancho + separacionX;
                figuraBloque.posicionX += separacionX + figuraBloque.ancho;


            }

            return bloquesManagement;
        }


        public Rectangle crear_plataforma(Canvas canvas_juego, Figura figuraPlataforma)
        {
            editar = new EditarRectangulo(figuraPlataforma);
            return (Rectangle)editar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }
    }
}
