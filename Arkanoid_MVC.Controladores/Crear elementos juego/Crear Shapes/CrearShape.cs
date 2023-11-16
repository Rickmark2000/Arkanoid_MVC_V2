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
using Arkanoid_MVC.Controladores.Crear_elementos_juego.Posicion_Bloques;

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
            IImplementarShape<Rectangle> implementar = new ImplementarRectangulo(figuraBloque);
            PosicionBloque posicion = new PosicionBloque();
            canvas_juego = posicion.posicionar_bloques(num_bloques, canvas_juego, with, figuraBloque, bloquesManagement, implementar);
            return bloquesManagement;
        }

        public Rectangle crear_plataforma(Canvas canvas_juego, Figura figuraPlataforma)
        {
            IImplementarShape<Rectangle> implementar = new ImplementarRectangulo(figuraPlataforma);
            return implementar.Implementar(ref canvas_juego, Colors.Red, Colors.Black, 2);
        }
    }
}
