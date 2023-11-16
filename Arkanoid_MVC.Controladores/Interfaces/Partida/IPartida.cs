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

namespace Arkanoid_MVC.Modelos.Interfaces
{
    public interface IPartida
    {
        void prepararJuego(double Width, double Height, Canvas CanvasJuego);
        void Guardar_posiciones_iniciales();
        void actualizar_colisiones(ref Canvas CanvasJuego, ref int puntuacion_actual);
        void actualizar_pos();
        bool gameOver();
        void actualizar_posJugador(ControlesJugador controles, ref Canvas CanvasJuego);
        void terminar_partida(DispatcherTimer timer, int score, Conexiones conexion);
    }
}
