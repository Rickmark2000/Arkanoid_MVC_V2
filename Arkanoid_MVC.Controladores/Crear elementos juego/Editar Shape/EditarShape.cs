
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arkanoid_MVC.Modelos.Interfaces;
using System.Windows.Documents;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Controladores.Factory;

namespace Arkanoid_MVC.Controladores.Diseño_Figuras
{
    public abstract class EditarShape : IEditarShape
    {
        protected Figura figura;
        protected IFactory<Shape> factory;

        public EditarShape(Figura figura)
        {
            this.figura = figura;
            factory = new FactoryShape();
        }

        public abstract Shape Implementar(ref Canvas element, Color color_fondo, Color color_borde, int grosor_borde);
    }

}
