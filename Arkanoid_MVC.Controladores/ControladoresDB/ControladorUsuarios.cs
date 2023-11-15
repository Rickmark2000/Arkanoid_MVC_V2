using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public class ControladorUsuarios : Controlador<Usuarios>
    {
        private IRepositorio<Usuarios> repositorio;
        private List<Usuarios> lista;

        public ControladorUsuarios(Conexiones conexiones) : base(conexiones)
        {
            repositorio = new RepositorioUsuarios(contexto);
            lista = listaObjetos();
        }

        public override List<Usuarios> listaObjetos()
        {
            return repositorio.leer();
        }

        public override void buscar(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override void buscar(int value)
        {
          repositorio.buscar(value);
        }

        public override void eliminar(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override void registrar(Usuarios entity)
        {
            repositorio.registrar(entity);
        }

        public override bool repetido(Usuarios entity)
        {
            throw new NotImplementedException();
        }

        public override void vaciar()
        {
           foreach (Usuarios usuario in lista)
            {
                repositorio.eliminar(usuario);
            }
        }
    }
}
