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
    public class ControladorJugadores : Controlador
    {
        private IRepositorio<Jugadores> repositorio;
        public ControladorJugadores(Conexiones conexiones) : base(conexiones)
        {
            repositorio = new RepositorioJugador(contexto);
        }
    }
}
