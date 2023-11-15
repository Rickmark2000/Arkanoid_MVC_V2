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

        public override void buscar(Jugadores entity)
        {
            throw new NotImplementedException();
        }

        public override void buscar(int value)
        {
            throw new NotImplementedException();
        }

        public override void eliminar(Jugadores entity)
        {
            throw new NotImplementedException();
        }

        public override void registrar(Jugadores entity)
        {
            throw new NotImplementedException();
        }

        public override bool repetido(Jugadores entity)
        {
            throw new NotImplementedException();
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
