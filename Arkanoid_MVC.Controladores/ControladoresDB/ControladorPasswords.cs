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
    public class ControladorPasswords : Controlador<Passwords>
    {
        private IRepositorio<Passwords> repositorio;
        private List<Passwords> lista;
        public ControladorPasswords(Conexiones conexiones) : base(conexiones)
        {
            repositorio = new RepositorioPassword(contexto);
            lista = listaObjetos();
        }

        public override List<Passwords> listaObjetos()
        {
            return repositorio.leer();
        }

        public override Passwords buscar(Passwords entity)
        {
            return lista.Find(n => n.Equals(entity));
        }

        public override Passwords buscar(int value)
        {
            return lista.Find(n => n.id.Equals(value));
        }

        public override void eliminar(Passwords entity)
        {
            repositorio.eliminar(entity);
        }

        public override void registrar(Passwords entity)
        {
            while (repetido(entity))
            {
                entity.id++;
            }

            repositorio.registrar(entity);
        }

        public override bool repetido(Passwords entity)
        {
            return lista.Any(n => n.id == entity.id);
        }

        public override void vaciar()
        {
            foreach (Passwords pass in lista)
            {
                repositorio.eliminar(pass);
            }
        }
    }
}
