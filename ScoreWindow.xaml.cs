using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.DB_Controller;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace Arkanoid_MVC
{

    public partial class ScoreWindow : Window
    {
        private Consulta conexionConsultas;
        public ScoreWindow(Conexiones conexion)
        {
            InitializeComponent();
            conexionConsultas = new Consulta(conexion);
           
            string consulta = $"select * from usuarios u WHERE u.Id ={conexion.idSesion}";

            /*
            string consulta = "select u.Id,u.nombre,j.nick,u.email,p.puntuacion,j.vidas " +
              "from jugadores j INNER JOIN usuarios u on j.idUsuario = u.Id " +
              $"inner join puntuaciones p on p.idJugador = j.id WHERE u.Id ={usuario.id}";
            */

            conexionConsultas.mostrar_select(consulta, datos);
        }
    }
}
