﻿using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public abstract class Controlador<I> : IControladores<I>, IListaClase<I>, IComprobarRepetido<I> where I : class
    {
        protected readonly Conexiones conexiones;
        protected DBContexto contexto;
        public Controlador(Conexiones conexiones)
        {
            this.conexiones = conexiones;
            contexto = new DBContexto(conexiones);

        }

        public abstract List<I> listaObjetos();

        public abstract I buscar(I entity);
        public abstract I buscar(int value);
        public abstract void eliminar(I entity);
        public abstract void registrar(I entity);
        public abstract bool repetido(I entity);
        public abstract void vaciar();
    }
}
