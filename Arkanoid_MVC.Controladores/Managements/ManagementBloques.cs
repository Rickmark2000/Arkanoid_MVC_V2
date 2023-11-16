using Arkanoid_MVC.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Controladores.Management
{
    public class ManagementBloques : IManagement<Rectangle>
    {

        private List<Rectangle> lista;

        public ManagementBloques()
        {
            lista = new List<Rectangle>();
        }

        public void anadir(Rectangle objeto)
        {
            lista.Add(objeto);
        }

        public Rectangle buscar(Rectangle value)
        {
            if (lista.Contains(value))
            {
                return lista.Find(n => n.Equals(value));
            }
            else { return null; }
        }

        public void eliminar(Rectangle value)
        {
            lista.Remove(value);
        }

        public List<Rectangle> ObtenerBloques()
        {
            return lista.ToList();
        }


    }
}
