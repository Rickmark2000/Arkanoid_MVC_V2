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
using System.Windows.Media;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Diseño_Figuras
{
    public class EditarElipse : EditarShape
    {
        public EditarElipse(Figura figura) : base(figura)
        {
        }

        public override Shape Implementar(ref Canvas element, Color color_fondo, Color color_borde, int grosor_borde)
        {            
            Ellipse bola = (Ellipse)factory.crear_figura(ETipoShape.Elipse);
            bola.Width = figura.tamano;
            bola.Height = figura.tamano;
            Canvas.SetTop(bola, figura.posicionY);
            Canvas.SetLeft(bola, figura.posicionX);
            bola.Fill = new SolidColorBrush(color_fondo);
            bola.Stroke = new SolidColorBrush(color_borde);
            bola.StrokeThickness = grosor_borde;
            element.Children.Add(bola);
            return bola;
        }
    }
}
