using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Interfaces.Controles
{
    public interface IControles<I> where I : Shape
    {
        void mover(I o, ref double posX, Canvas CanvasJuego);
    }
}
