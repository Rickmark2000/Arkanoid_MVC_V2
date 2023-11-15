using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public class ControladorPasswords : Controlador<Passwords>
    {
        public ControladorPasswords(Conexiones conexiones) : base(conexiones)
        {
        }

        public override List<Passwords> listaObjetos => throw new NotImplementedException();

        public override bool repetido(Passwords entity)
        {
            throw new NotImplementedException();
        }
    }
}
