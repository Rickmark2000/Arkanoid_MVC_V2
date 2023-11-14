using System;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class ElipseFactory:ShapeFactory
    {

        public override Shape crear()
        {
            return new Ellipse();
        }
    }
}