using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using Microsoft.VisualBasic;
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
        public override Usuarios buscar(Usuarios entity)
        {
            return lista.FirstOrDefault(n => n.usuario.Equals(entity.usuario));
        }

        public override Usuarios buscar(int value)
        {
            return lista.Find(n => n.id.Equals(value));
        }

        public override void eliminar(Usuarios entity)
        {
            repositorio.eliminar(entity);
            lista = listaObjetos();
        }

        public override void registrar(Usuarios entity)
        {
            while (repetido(entity))
            {
                entity.id++;
            }

            repositorio.registrar(entity);
            lista = listaObjetos();
        }

        public override bool repetido(Usuarios entity)
        {
            return lista.Any(n => n.id == entity.id);
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
