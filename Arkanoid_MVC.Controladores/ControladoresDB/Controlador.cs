using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.ContextoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public abstract class Controlador
    {
        protected readonly Conexiones conexiones;
        protected DBContexto contexto;
        public Controlador(Conexiones conexiones)
        {
            this.conexiones = conexiones;
            contexto = new DBContexto(conexiones.conexion);
            
        }
    }
}
