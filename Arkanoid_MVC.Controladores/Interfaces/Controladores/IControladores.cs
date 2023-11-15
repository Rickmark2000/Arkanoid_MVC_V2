using Arkanoid_MVC.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Interfaces
{
    public interface IControladores<I> where I : class
    {
        void vaciar();

        void eliminar(I entity);

        void registrar(I entity);

        I buscar(I entity);

        I buscar(int value);

    }
}
