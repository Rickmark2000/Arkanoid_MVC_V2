using Arkanoid_MVC.Controladores.DB_Controller;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Arkanoid_MVC.Controladores.Conexion
{
    public class Conexiones
    {
        protected string conexion;
        private string raizProyecto;
        private DBConsultas consultas;

        public Conexiones(string conexion,string raizProyecto) 
        {
            this.conexion = conexion;
            this.raizProyecto = raizProyecto;
            consultas = new DBConsultas(conexion, raizProyecto);
        }

        public Conexiones(string conexion)
        {
            this.conexion=conexion;
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

        public void mostrar_select(string consulta,DataGrid datos)
        {
            
            consultas.mostrar_select(consulta, datos);
        }

        public List<Object> recuperar_select<I>(string consulta) where I : class
        {
            return consultas.recuperar_consulta<I>(consulta);
        }
    }
}
