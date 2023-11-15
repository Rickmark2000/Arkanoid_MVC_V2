using Arkanoid_MVC.Modelos.ContextoDB;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Repositorios
{
    public class RepositorioJugador : IRepositorio<Jugadores>
    {
        private readonly DBContexto context;

        public RepositorioJugador(DBContexto contexto)
        {
            context = contexto;
        }

        public async Task<Jugadores> buscar( Jugadores entity)
        {
            return await context.jugadores.FirstOrDefaultAsync(n => n == entity);
        }

        public async Task<Jugadores> buscar(int value)
        {
            return await context.jugadores.FirstOrDefaultAsync(n => n.id == value);
        }

        public async Task eliminar(Jugadores entity)
        {
            context.jugadores.Remove(entity);
            await context.SaveChangesAsync();

        }

        public List<Jugadores> leer()
        {
            return context.jugadores.ToList();
        }

        public async Task registrar(Jugadores entity)
        {
            context.jugadores.Add(entity);
            await context.SaveChangesAsync();

        }
    }
}
