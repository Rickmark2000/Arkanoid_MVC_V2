using Arkanoid_MVC.Controladores.Factory;
using Arkanoid_MVC.Modelos.Enumeraciones;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Diseño_Figuras
{
    public class ImplementarRectangulo : ImplementarShape<Rectangle>
    {
        private int num_bloques;
        private IManagement<Rectangle> management;
        private double with;

        public ImplementarRectangulo(Figura figura) : base(figura)
        {
        }

        public ImplementarRectangulo(Figura figura, int num_bloques, IManagement<Rectangle> bloquesManagement, double with) : this(figura)
        {
            this.num_bloques = num_bloques;
            this.management = bloquesManagement;
            this.with = with;
        }

        public override Rectangle Implementar(ref Canvas element, Color color_fondo, Color color_borde, int grosor_borde)
        {
            if (factory.crear_figura(ETipoShape.Rectangulo).GetType() == typeof(Rectangle))
            {
                Rectangle plataforma = (Rectangle)factory.crear_figura(ETipoShape.Rectangulo);
                editar_plataforma(element, color_fondo, color_borde, 2, plataforma);
                return plataforma;
            }
            else
            {
                return null;
            }
        }

        private void editar_plataforma(Canvas element, Color color_fondo, Color color_borde, int grosor_borde, Rectangle plataforma)
        {
            plataforma.Width = figura.ancho;
            plataforma.Height = figura.alto;
            Canvas.SetTop(plataforma, figura.posicionY);
            Canvas.SetLeft(plataforma, figura.posicionX);
            plataforma.Fill = new SolidColorBrush(color_fondo);
            plataforma.Stroke = new SolidColorBrush(color_borde);
            plataforma.StrokeThickness = grosor_borde;
            element.Children.Add(plataforma);
        }


    }
}

