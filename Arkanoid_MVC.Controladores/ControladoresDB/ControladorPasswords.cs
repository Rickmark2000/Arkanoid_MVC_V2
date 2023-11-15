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

        public override void buscar(Passwords entity)
        {
            throw new NotImplementedException();
        }

        public override void buscar(int value)
        {
            throw new NotImplementedException();
        }

        public override void eliminar(Passwords entity)
        {
            throw new NotImplementedException();
        }

        public override void registrar(Passwords entity)
        {
            throw new NotImplementedException();
        }

        public override bool repetido(Passwords entity)
        {
            throw new NotImplementedException();
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
