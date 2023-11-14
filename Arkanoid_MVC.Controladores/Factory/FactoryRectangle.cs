using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Factory
{
    public class FactoryRectangle : FactoryShape
    {

        public override Shape crear()
        {
            return new Rectangle();
        }
    }
}
