using Arkanoid_MVC.Modelos.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Modelos
{
    public abstract class Figura
    {
        public double ancho { get; set; }
        public double alto { get; set; }
        public double tamano { get; set; }
        public double posicionX { get; set; }
        public double posicionY { get; set; }
        public ETipoShape tipoFigura { get; set; }

        public Figura(ETipoShape tipo)
        {
            this.tipoFigura = tipo;
        }
    }
}
