
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
        private Usuarios usuario = new Usuarios(2,"cc", "jj", "poug@outlook.com", "criiiiiii");
        private string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
        private string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        private Conexiones conexion;

        public MainWindow()
        {
            InitializeComponent();
            boton_login.Content = "Logearse";
            boton_registro.Content = "Registrarse";

            conexion = new Conexiones(connectionString, proyectoRaiz,usuario.id);
        }

        private void Button_Registrar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dsadsa");
        }

        private void boton_login_Click(object sender, RoutedEventArgs e)
        {

            Menu_Principal menu = new Menu_Principal(conexion);
            menu.Show();
            this.Close();
        }
    }
}
