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
    public class ControladorJugadores : Controlador<Jugadores>
    {
        private IRepositorio<Jugadores> repositorio;
        private List<Jugadores> lista;
        public ControladorJugadores(Conexiones conexiones) : base(conexiones)
        {
            repositorio = new RepositorioJugador(contexto);
            lista = listaObjetos();
        }

        public override List<Jugadores> listaObjetos()
        {
            return repositorio.leer();
        }

        public override Jugadores buscar(Jugadores entity)
        {
            return lista.Find(n=>n.Equals(entity));
        }

        public override Jugadores buscar(int value)
        {
            return lista.Find(n => n.id.Equals(value));
        }

        public override void eliminar(Jugadores entity)
        {
            repositorio.eliminar(entity);
        }

        public override void registrar(Jugadores entity)
        {
            while (repetido(entity))
            {
                entity.id++;
            }

            repositorio.registrar(entity);
        }

        public override bool repetido(Jugadores entity)
        {
            return lista.Any(n=>n.id == entity.id);
        }

        public override void vaciar()
        {
            foreach(Jugadores jugador in lista)
            {
                repositorio.eliminar(jugador);
            }
        }
    }
}
