
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
        Task registrar(Entity entity);

        Task eliminar(Entity entity);

        Task<Entity> buscar(Entity entity);

        Task<Entity> buscar(int value);

        Task<List<Entity>> leer();

    }
}
