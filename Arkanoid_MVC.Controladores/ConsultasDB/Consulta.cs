using Arkanoid_MVC.Controladores.DB_Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Arkanoid_MVC.Controladores.Conexion
{
    public class Consulta
    {

        private DBConsultas consultas;

        public Consulta(Conexiones conexiones)
        {
            consultas = new DBConsultas(conexiones.conexion,conexiones.raizProyecto);
        }

        public void mostrar_select(string consulta, DataGrid datos)
        {

            consultas.mostrar_select(consulta, datos);
        }

        public List<Object> recuperar_select<I>(string consulta) where I : class
        {
            return consultas.recuperar_consulta<I>(consulta);
        }
    }
}
