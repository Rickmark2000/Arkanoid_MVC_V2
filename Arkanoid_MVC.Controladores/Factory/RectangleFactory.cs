using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class RectangleFactory : ShapeFactory
    {

        public override Shape crear()
        {
            return new Rectangle();
        }
    }
}
