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

        public async Task<Passwords> buscar(Passwords entity)
        {
            return await context.passwords.FirstOrDefaultAsync(n => n == entity);
        }

        public async Task<Passwords> buscar(int value)
        {
            return await context.passwords.FirstOrDefaultAsync(n => n.id == value);
        }

        public async Task eliminar(Passwords entity)
        {
            context.passwords.Remove(entity);
            await context.SaveChangesAsync();

        }

        public List<Passwords> leer()
        {
            return context.passwords.ToList();
        }

        public async Task registrar(Passwords entity)
        {
            context.passwords.Add(entity);
            await context.SaveChangesAsync();

        }
    }
}
