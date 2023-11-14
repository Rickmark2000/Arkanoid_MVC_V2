using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Arkanoid_MVC.Modelos.Interfaces;

namespace Arkanoid_MVC.Controladores.Factory
{
    public abstract class ShapeFactory : IfigurasFactory<Shape>
    {
        public static Shape crear_figura(ETipoFigura tipo)
        {
            Shape figura = null;
            switch (tipo)
            {
                case ETipoFigura.Rectangulo:
                    figura = new RectangleFactory().crear();
                    break;
                case ETipoFigura.Elipse:
                    figura = new ElipseFactory().crear();
                    break;

            }
            
            return figura;
        }
        public abstract Shape crear();

    }
}
