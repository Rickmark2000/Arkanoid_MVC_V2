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
        private string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
       

        public ScoreWindow()
        {
            InitializeComponent();


        string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            DBConsultas db_controller = new DBConsultas(connectionString,proyectoRaiz);
            
            string consulta = "select u.Id,u.nombre,j.nick,u.email,p.puntuacion,j.vidas " +
              "from jugadores j INNER JOIN usuarios u on j.idUsuario = u.Id " +
              "inner join puntuaciones p on p.idJugador = j.id";


            db_controller.mostrar_select(consulta,datos);

        }

        public void vaciar_db(DBConsultas db_controller)
        {
            //db_controller.eliminar_tabla<Puntuaciones>(puntuaciones);
            //db_controller.eliminar_tabla<Passwords>(password);
            //db_controller.eliminar_tabla<Jugadores>(jugadores);
            //db_controller.eliminar_tabla<Usuarios>(usuarios);
        }

    

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IRepositorio<Jugadores> jugadores = new RepositorioJugador<Jugadores>(connectionString);
            IRepositorio<Puntuaciones> puntuaciones = new RepositorioPuntuacion<Puntuaciones>(connectionString);
            IRepositorio<Usuarios> usuarios = new RepositorioUsuarios<Usuarios>(connectionString);
            IRepositorio<Passwords> password = new RepositorioPassword<Passwords>(connectionString);
    }
    }
}
