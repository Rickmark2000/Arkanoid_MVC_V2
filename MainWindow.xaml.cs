
using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Controladores.ControladoresDB;
using Arkanoid_MVC.Controladores.Interfaces;
using Arkanoid_MVC.Modelos.Interfaces;
using Arkanoid_MVC.Modelos.Modelos;
using Arkanoid_MVC.Modelos.Repositorios;
using Arkanoid_MVC.Vista;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;


namespace Arkanoid_MVC
{

    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Arkanoid"].ConnectionString;
        private string connectionString2 = ConfigurationManager.ConnectionStrings["ArkanoidMVC"].ConnectionString;
        
        private string proyectoRaiz = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
        private Conexiones conexion;
        private IControladores<Usuarios> usuarios;
        private IControladores<Passwords> contrasenas;

        public MainWindow()
        {
            InitializeComponent();
           
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            boton_login.Content = "Logearse";
            boton_registro.Content = "Registrarse";

            conexion = new Conexiones(connectionString, proyectoRaiz);

        }

        private void Button_Registrar(object sender, RoutedEventArgs e)
        {
            string pass = registro_contrasena.Password;
            string nombre_usuario = registro_usuario.Text;
            string mail = registro_email.Text;
            string nombre = registro_nombre.Text;
            string apellidos = registro_apellidos.Text;
            Usuarios usuario = new Usuarios(nombre,apellidos,mail,nombre_usuario);
            usuarios = new ControladorUsuarios(conexion);
            contrasenas = new ControladorPasswords(conexion);

            if (usuarios.buscar(usuario) == null)
            {

                usuarios.registrar(usuario);
                int id = usuarios.buscar(usuario).id;
                Passwords password = new Passwords(1, id, pass);
                contrasenas.registrar(password);
                conexion.idSesion = id;
                MessageBox.Show("Usuario registrado");

                Menu_Principal menu = new Menu_Principal(conexion);
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error, ese usuario ya existe");
            }
            
        }

        private void boton_login_Click(object sender, RoutedEventArgs e)
        {
            string contrasena = login_contrasena.Password;
            string usuario = login_usuario.Text;
            usuarios = new ControladorUsuarios(conexion);
            contrasenas = new ControladorPasswords(conexion);
            Usuarios usuario_login = usuarios.buscar(new Usuarios(usuario));
            Passwords pass_login = contrasenas.buscar(new Passwords(3,contrasena));

            if ( usuario_login != null && pass_login != null)
            {
                conexion.idSesion = usuario_login.id;
                MessageBox.Show("Sesion iniciada");

                Menu_Principal menu = new Menu_Principal(conexion);
                menu.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Error en los datos");
            }
            
        }
    }
}
