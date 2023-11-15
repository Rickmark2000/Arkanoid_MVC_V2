using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public class FiguraVelocidad : Figura
    {
        public FiguraVelocidad(ETipoShape tipo) : base(tipo)
        {
        }

        public int velocidad { get; set; }



    }
}
