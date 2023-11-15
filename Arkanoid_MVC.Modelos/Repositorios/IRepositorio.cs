
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IRepositorio<Entity> where Entity : class
    {
        void registrar(Entity entity);

        void eliminar(Entity entity);

        List<Entity> leer();

    }
}
