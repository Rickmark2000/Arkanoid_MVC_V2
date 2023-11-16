using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Arkanoid_MVC.Controladores.Controles;
using Arkanoid_MVC.Controladores.Conexion;
using System.Windows.Threading;
using Arkanoid_MVC.Controladores.Interfaces.Controles;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IPartida<I> where I : Shape
    {
        void prepararJuego(double Width,Canvas CanvasJuego);
        void Guardar_posiciones_iniciales();
        void actualizar_colisiones(ref Canvas CanvasJuego, ref int puntuacion_actual);
        void actualizar_pos();
        bool gameOver();
        void actualizar_posJugador(IControles<I> controles, ref Canvas CanvasJuego);
        void terminar_partida(DispatcherTimer timer, int score, Conexiones conexion);
    }
}
