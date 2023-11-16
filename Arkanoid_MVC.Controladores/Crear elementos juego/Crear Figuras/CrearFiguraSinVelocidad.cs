using Arkanoid_MVC.Controladores.Interfaces.Diseño_Canvas;
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
    public class CrearFiguraSinVelocidad : CrearFigura<FiguraSinVelocidad>
    {
        public override FiguraSinVelocidad crear(double ancho, double alto, double tamano, double posicionX, double posicionY,ETipoFigura tipo)
        {
            
            if(factory.crear_figura(tipo).GetType() == typeof(FiguraSinVelocidad))
            {
                FiguraSinVelocidad figura = (FiguraSinVelocidad)factory.crear_figura(ETipoFigura.SinVelocidad);
                figura.posicionX = posicionX;
                figura.posicionY = posicionY;
                figura.ancho = ancho;
                figura.alto = alto;
                figura.tamano = tamano;
                return figura;
            }
            else
            {
                return null;
            }
           
        }

        public override FiguraSinVelocidad crear(double ancho, double alto, double posicionX, double posicionY, ETipoFigura tipo)
        {
            if (factory.crear_figura(tipo).GetType() == typeof(FiguraSinVelocidad))
            {
                FiguraSinVelocidad figura = (FiguraSinVelocidad)factory.crear_figura(ETipoFigura.SinVelocidad);
                figura.posicionX = posicionX;
                figura.posicionY = posicionY;
                figura.ancho = ancho;
                figura.alto = alto;
                return figura;
            }
            else
            {
                return null;
            }
        }

        public override FiguraSinVelocidad crear(double tamano, double posicionX, double posicionY, ETipoFigura tipo)
        {
            if (factory.crear_figura(tipo).GetType() == typeof(FiguraSinVelocidad))
            {
                FiguraSinVelocidad figura = (FiguraSinVelocidad)factory.crear_figura(ETipoFigura.SinVelocidad);
                figura.posicionX = posicionX;
                figura.posicionY = posicionY;
                figura.tamano = tamano;
                return figura;
            }
            else
            {
                return null;
            }
        }
    }
}
