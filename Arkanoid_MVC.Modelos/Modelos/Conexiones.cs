using Arkanoid_MVC.Controladores.DB_Controller;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Arkanoid_MVC.Controladores.Conexion
{
    public class Conexiones
    {
        public string conexion { get; set; }
        public string raizProyecto { get; set; }
        public Conexiones(string conexion,string raizProyecto) 
        {
            this.conexion = conexion;
            this.raizProyecto = raizProyecto;
            
        }

        public Conexiones(string conexion)
        {
            this.conexion=conexion;
        }
        
    }
}
