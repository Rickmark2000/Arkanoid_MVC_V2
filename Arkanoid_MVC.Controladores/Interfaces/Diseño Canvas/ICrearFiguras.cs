﻿using Arkanoid_MVC.Modelos.Enumeraciones;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Interfaces.Diseño_Canvas
{
    public interface ICrearFiguras<I> where I:Figura
    {
        I crear(double ancho, double alto, double tamano, double posicionX, double posicionY, ETipoFigura tipo);
        I crear(double ancho, double alto, double posicionX, double posicionY, ETipoFigura tipo);
        I crear(double tamano, double posicionX, double posicionY, ETipoFigura tipo);
    }
}
