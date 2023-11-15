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

        public override void buscar(Puntuaciones entity)
        {
            throw new NotImplementedException();
        }

        public override void buscar(int value)
        {
            throw new NotImplementedException();
        }

        public override void eliminar(Puntuaciones entity)
        {
            throw new NotImplementedException();
        }

        public override void registrar(Puntuaciones entity)
        {
            throw new NotImplementedException();
        }

        public override bool repetido(Puntuaciones entity)
        {
            throw new NotImplementedException();
        }

        public override void vaciar()
        {
            foreach(Puntuaciones puntuaciones in lista)
            {
                repositorio.eliminar(puntuaciones);
            }
        }
    }
}
