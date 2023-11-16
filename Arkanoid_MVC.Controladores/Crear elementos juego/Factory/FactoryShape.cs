using Arkanoid_MVC.Modelos.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Arkanoid_MVC.Modelos.Interfaces;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class FactoryShape : IFactory<Shape>
    {
        public Shape crear_figura(Enum tipo)
        {
            switch (tipo)
            {
                case ETipoShape.Rectangulo:
                    return new Rectangle();
                case ETipoShape.Elipse:
                    return new Ellipse();

            }

            return null;
        }

    }
}
