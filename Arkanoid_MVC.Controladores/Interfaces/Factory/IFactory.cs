using Arkanoid_MVC.Modelos.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IFactory<Objeto> where Objeto : class
    {
        Objeto crear_figura(Enum tipo);

    }
}
