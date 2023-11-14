using System;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class FactoryElipse:FactoryShape
    {

        public override Shape crear()
        {
            return new Ellipse();
        }
    }
}