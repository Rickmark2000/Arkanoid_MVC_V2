﻿using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Repositorios
{
    public class PuntuacionRepositorio<I> : IRepositorio<I> where I : Puntuaciones
    {
        private readonly DBContexto<I> context;
        public List<I> listaObjetos { get; }

        public PuntuacionRepositorio(string conexion)
        {
            context = new DBContexto<I>(conexion);
            listaObjetos = context.Puntuaciones.ToList();
        }

        public I buscar(I entity)
        {
            return listaObjetos.Find(n => n == entity);
        }

        public I buscar(int value)
        {
            return listaObjetos.Find(n => n.id == value);
        }

        public void eliminar(I entity)
        {
            I jugador = buscar(entity);
            context.Puntuaciones.Remove(jugador);
            context.SaveChanges();

        }

        public List<I> leer()
        {
            return listaObjetos;
        }

        public void registrar(I entity)
        {
            while (repetido(entity.id))
            {
                entity.id++;
            }
            context.Puntuaciones.Add(entity);
            context.SaveChanges();

        }

        public bool repetido(I entity)
        {
            return listaObjetos.Any(e => e.Equals(entity));
        }
        public bool repetido(int entity)
        {
            return listaObjetos.Any(e => e.id.Equals(entity));
        }
    }
}
