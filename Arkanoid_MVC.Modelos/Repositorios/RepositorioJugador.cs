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

        public void eliminar(Jugadores entity)
        {
            context.jugadores.Remove(entity);
            context.SaveChanges();

        }

        public List<Jugadores> leer()
        {
            return context.jugadores.ToList();
        }

        public void registrar(Jugadores entity)
        {
            context.jugadores.Add(entity);
            context.SaveChanges();

        }
    }
}
