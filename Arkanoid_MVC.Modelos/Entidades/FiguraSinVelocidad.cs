using Arkanoid_MVC.Modelos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public class FiguraSinVelocidad:Figura
    {
        public FiguraSinVelocidad(ETipoShape tipo) : base(tipo)
        {
        }

        public int numGolpes {  get; set; }
    }
}
