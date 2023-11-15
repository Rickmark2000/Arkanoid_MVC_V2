using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Arkanoid_MVC.Modelos.Repositorios
{
    public class RepositorioPassword : IRepositorio<Passwords>
    {
        private readonly DBContexto context;

        public RepositorioPassword(DBContexto contexto)
        {
            context = contexto;
        }
        

        public void eliminar(Passwords entity)
        {
            context.passwords.Remove(entity);
            context.SaveChanges();

        }

        public List<Passwords> leer()
        {
            return context.passwords.ToList();
        }

        public void registrar(Passwords entity)
        {
            context.passwords.Add(entity);
            context.SaveChanges();

        }
    }
}
