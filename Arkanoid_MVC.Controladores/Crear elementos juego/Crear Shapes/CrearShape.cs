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
using System.Windows.Documents;

namespace Arkanoid_MVC.Controladores.Juego
{
    public class CrearShape
    {

        public Ellipse crear_bola(Canvas canvas_juego, Figura figuraBola)
        {
            IImplementarShape<Ellipse> implementar = new ImplementarElipse(figuraBola);
            return implementar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }

        public IManagement<Rectangle> crear_bloques(int num_bloques, Canvas canvas_juego, double with, Figura figuraBloque)
        {
            IManagement<Rectangle> bloquesManagement = new ManagementBloques();
            IImplementarShape<Rectangle> implementar = new ImplementarRectangulo(figuraBloque, num_bloques, bloquesManagement, with);
            canvas_juego = posicionar_bloques(num_bloques, canvas_juego, with, figuraBloque, bloquesManagement, implementar);
            return bloquesManagement;
        }

        private Canvas posicionar_bloques(int num_bloques, Canvas canvas_juego, double with, Figura figuraBloque, IManagement<Rectangle> bloquesManagement, IImplementarShape<Rectangle> implementar)
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

        public Rectangle crear_plataforma(Canvas canvas_juego, Figura figuraPlataforma)
        {
            IImplementarShape<Rectangle> implementar = new ImplementarRectangulo(figuraPlataforma);
            return implementar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }
    }
}
