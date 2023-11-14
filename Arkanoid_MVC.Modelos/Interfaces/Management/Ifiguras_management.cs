﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Modelos.Interfaces
{ 
    public interface Ifiguras_management<T>:Ilista_figura<T>
    {
       
        void anadir(T objeto);

        T buscar(T value);

        void eliminar(T value);

        List<T> ObtenerBloques();

    }
}
