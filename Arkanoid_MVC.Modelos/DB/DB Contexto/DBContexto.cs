
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.ContextoDB
{
    public class DBContexto: DbContext 
    {
        private Conexiones _context;
        public DbSet<Jugadores> jugadores { get; set; }
        public DbSet<Puntuaciones> Puntuaciones { get; set; }
        public DbSet<Passwords> passwords { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        public DBContexto(Conexiones context)
        {
            this._context = context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", _context.raizProyecto);
            optionsBuilder.UseSqlServer(_context.conexion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuarios>().HasKey(n => n.id);
            modelBuilder.Entity<Usuarios>().Property(n => n.id).ValueGeneratedOnAdd();
            Assembly assemblyWithConfigurations = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
