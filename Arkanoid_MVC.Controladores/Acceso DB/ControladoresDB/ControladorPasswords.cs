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
            return lista.FirstOrDefault(n => n.password.Contains(entity.password));
        }

        public override Passwords buscar(int value)
        {
            return lista.Find(n => n.id.Equals(value));
        }

        public override void eliminar(Passwords entity)
        {
            repositorio.eliminar(entity);
            lista = listaObjetos();
        }

        public override void registrar(Passwords entity)
        {
            repositorio.registrar(entity);
            lista = listaObjetos();
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
