using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Arkanoid_MVC.Modelos.Enum;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IObservarColision<I,E> where I : Shape
    {
       ETipoColision estado(I figura, Canvas element);

        ETipoColision estado(I figura, E element);
    }
}
