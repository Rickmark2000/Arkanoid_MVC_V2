using Arkanoid_MVC.Controladores.DB_Controller;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.Conexion
{
    public class AccionesRepositorios
    {
        private Conexiones Conexiones;
        private string conexion;
        public AccionesRepositorios(Conexiones conexiones)
        {
         this.Conexiones = conexiones;
         conexion = Conexiones.conexion;
        }

        public void vaciar_DB()
        {
            

            IRepositorio<Jugadores> jugadores = new RepositorioJugador<Jugadores>(conexion);
            IRepositorio<Puntuaciones> puntuaciones = new RepositorioPuntuacion<Puntuaciones>(conexion);
            IRepositorio<Usuarios> usuarios = new RepositorioUsuarios<Usuarios>(conexion);
            IRepositorio<Passwords> password = new RepositorioPassword<Passwords>(conexion);

            eliminar_tabla<Puntuaciones>(puntuaciones);
            eliminar_tabla<Passwords>(password);
            eliminar_tabla<Jugadores>(jugadores);
            eliminar_tabla<Usuarios>(usuarios);
        }

        public void eliminar_tabla<I>(IRepositorio<I> elements) where I : class
        {
            foreach (I element in elements.leer())
            {
                elements.eliminar(element);
            }
        }
    }
}
