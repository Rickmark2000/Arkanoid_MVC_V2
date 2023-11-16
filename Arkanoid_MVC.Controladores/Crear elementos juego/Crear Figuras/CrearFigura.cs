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
    public abstract class CrearFigura<I> : ICrearFiguras<I> where I : Figura
    {
        protected IFactory<Figura> factory;
        public CrearFigura() 
        {
            factory = new FactoryFigura();
        }
        public abstract I crear(double ancho, double alto, double tamano, double posicionX, double posicionY, ETipoFigura tipo);
        public abstract I crear(double ancho, double alto, double posicionX, double posicionY, ETipoFigura tipo);
        public abstract I crear(double tamano, double posicionX, double posicionY, ETipoFigura tipo);
    }
}
