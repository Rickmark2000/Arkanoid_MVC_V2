using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Arkanoid_MVC.Modelos.Repositorios
{
    public class RepositorioUsuarios: IRepositorio<Usuarios>
    {

        private readonly DBContexto context;

        public RepositorioUsuarios(DBContexto contexto)
        {
            context = contexto;
        }

        public async Task<Usuarios> buscar(Usuarios entity)
        {
            return await context.Usuarios.FirstOrDefaultAsync(n => n == entity);
        }

        public async Task<Usuarios> buscar(int value)
        {
            return await context.Usuarios.FirstOrDefaultAsync(n => n.id == value);
        }

        public async Task eliminar(Usuarios entity)
        {
            context.Usuarios.Remove(entity);
            await context.SaveChangesAsync();

        }
        public List<Usuarios> leer()
        {
            return context.Usuarios.ToList();
        }

        public async Task registrar(Usuarios entity)
        {
            context.Usuarios.Add(entity);
            await context.SaveChangesAsync();

        }
    }
}
