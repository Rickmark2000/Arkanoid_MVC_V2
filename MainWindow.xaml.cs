
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.ControladoresDB;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using Arkanoid_MVC.Vista;
using System;
using System.Configuration;
using System.Windows;


namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {
        private Usuarios usuario = new Usuarios(1, "Carlos", "Castro", "carl@outlook.com", "Mark");
        private string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
        private string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        private Conexiones conexion;

        public MainWindow()
        {
            InitializeComponent();
            conexion = new Conexiones(connectionString, proyectoRaiz);
            IControladores<Usuarios> c = new ControladorUsuarios(conexion);

            conexion = new Conexiones(connectionString, proyectoRaiz);
            Menu_Principal menu = new Menu_Principal(usuario,conexion);
            menu.Show();
            this.Close();
        }

    }
}
