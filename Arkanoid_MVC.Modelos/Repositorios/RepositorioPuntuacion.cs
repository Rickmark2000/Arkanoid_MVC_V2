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

     

        public async Task eliminar(Puntuaciones entity)
        {
            context.Puntuaciones.Remove(entity);
            await context.SaveChangesAsync();

        }

        public List<Puntuaciones> leer()
        {
            return context.Puntuaciones.ToList();
        }

        public async Task registrar(Puntuaciones entity)
        {
            context.Puntuaciones.Add(entity);
            await context.SaveChangesAsync();

        }

    }
}
