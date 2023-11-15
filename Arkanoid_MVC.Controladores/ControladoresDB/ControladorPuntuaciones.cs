using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_MVC.Controladores.ControladoresDB
{
    public class ControladorPuntuaciones : Controlador<Puntuaciones>
    {
        public ControladorPuntuaciones(Conexiones conexiones) : base(conexiones)
        {
        }

        public override List<Puntuaciones> listaObjetos => throw new NotImplementedException();

        public override bool repetido(Puntuaciones entity)
        {
            throw new NotImplementedException();
        }
    }
}
