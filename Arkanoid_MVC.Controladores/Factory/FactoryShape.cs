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
    public abstract class FactoryShape : IfigurasFactory<Shape>
    {
        public static Shape crear_figura(ETipoShape tipo)
        {
            Shape figura = null;
            switch (tipo)
            {
                case ETipoShape.Rectangulo:
                    figura = new FactoryRectangle().crear();
                    break;
                case ETipoShape.Elipse:
                    figura = new FactoryElipse().crear();
                    break;

            }
            
            return figura;
        }
        public abstract Shape crear();

    }
}
