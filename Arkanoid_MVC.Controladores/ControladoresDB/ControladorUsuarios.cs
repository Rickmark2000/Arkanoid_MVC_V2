using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public class ControladorUsuarios : Controlador<Usuarios>
    {
        public ControladorUsuarios(Conexiones conexiones) : base(conexiones)
        {
        }

        public override List<Usuarios> listaObjetos => throw new NotImplementedException();

        public override bool repetido(Usuarios entity)
        {
            throw new NotImplementedException();
        }
    }
}
