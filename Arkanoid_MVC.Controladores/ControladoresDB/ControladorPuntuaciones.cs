using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public class ControladorPuntuaciones : Controlador<Puntuaciones>
    {
        private IRepositorio<Puntuaciones> repositorio;
        private List<Puntuaciones> lista;

        public ControladorPuntuaciones(Conexiones conexiones) : base(conexiones)
        {
            repositorio = new RepositorioPuntuacion(contexto);
            lista = listaObjetos();
        }

        public override List<Puntuaciones> listaObjetos()
        {
            return repositorio.leer();
        }

        public override Puntuaciones buscar(Puntuaciones entity)
        {
            return lista.Find(n => n.Equals(entity));
        }

        public override Puntuaciones buscar(int value)
        {
            return lista.Find(n => n.id.Equals(value));
        }

        public override void eliminar(Puntuaciones entity)
        {
            repositorio.eliminar(entity);
        }

        public override void registrar(Puntuaciones entity)
        {
            while (repetido(entity))
            {
                entity.id++;
            }

            repositorio.registrar(entity);
        }

        public override bool repetido(Puntuaciones entity)
        {
            return lista.Any(n => n.id == entity.id);
        }

        public override void vaciar()
        {
            foreach (Puntuaciones puntuaciones in lista)
            {
                repositorio.eliminar(puntuaciones);
            }
        }
    }
}
