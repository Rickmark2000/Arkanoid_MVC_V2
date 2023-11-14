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
    public class RepositorioPuntuacion : IRepositorio<Puntuaciones> 
    {
        private readonly DBContexto context;

        public RepositorioPuntuacion(DBContexto contexto)
        {
            context = contexto;
        }

        public async Task<Puntuaciones> buscar(Puntuaciones entity)
        {
            return await context.Puntuaciones.FirstOrDefaultAsync(n => n == entity);
        }

        public async Task<Puntuaciones> buscar(int value)
        {
            return await context.Puntuaciones.FirstOrDefaultAsync(n => n.id == value);
        }

        public async Task eliminar(Puntuaciones entity)
        {
            context.Puntuaciones.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<List<Puntuaciones>> leer()
        {
            return await context.Puntuaciones.ToListAsync();
        }

        public async Task registrar(Puntuaciones entity)
        {
            context.Puntuaciones.Add(entity);
            await context.SaveChangesAsync();

        }

    }
}
