using Arkanoid_MVC.Modelos.Enumeraciones;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Crear_elementos_juego.Crear_Figuras
{
    public class FactoryFigura : IFactory<Figura>
    {
        private ETipoShape tipoShape;

        public FactoryFigura(ETipoShape tipoShape)
        {
            this.tipoShape = tipoShape;
        }

        public Figura crear_figura(Enum tipo)
        {
            switch (tipo)
            {
                case ETipoFigura.Velocidad:
                    return new FiguraVelocidad(tipoShape);
                case ETipoFigura.SinVelocidad:
                    return new FiguraSinVelocidad(tipoShape);
            }
            return null;
        }
    }
}
