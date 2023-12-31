﻿using Arkanoid_MVC.Controladores.Conexion;
using Arkanoid_MVC.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arkanoid_MVC.Vista
{
    /// <summary>
    /// Lógica de interacción para Menu_Principal.xaml
    /// </summary>
    public partial class Menu_Principal : Window
    {
        private Conexiones conexion;
        public Menu_Principal(Conexiones conexiones)
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.conexion = conexiones;
            Title = "Menu principal";
            empezar.Content = "Empezar partida";
            salir.Content = "Salir";
            score.Content = "Score Board";

        }

        public void empezar_partida(object sender, RoutedEventArgs e)
        {
            
            Juego_arkanoid juego = new Juego_arkanoid(conexion);
            juego.Show();
            this.Close();
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void score_Click(object sender, RoutedEventArgs e)
        {

            ScoreWindow score = new ScoreWindow(conexion);
            score.Show();

        }

      
    }
}
