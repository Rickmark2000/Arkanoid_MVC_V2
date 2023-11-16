using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Arkanoid_MVC.Modelos.Interfaces;
using System.Collections.Generic;
using System;

namespace Arkanoid_MVC.Controladores.DB_Controller
{
    public class DBConsultas
    {
        private string contexto;

        public DBConsultas(string contexto,string directorioBase)
        {
            this.contexto = contexto;
            AppDomain.CurrentDomain.SetData("DataDirectory", directorioBase);
        }

        public void mostrar_select(string consulta, System.Windows.Controls.DataGrid datos)
        {
            using (SqlConnection conexion = new SqlConnection(contexto))
            {
                var bindingSource = new BindingSource();
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    try
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adaptador);

                        DataTable table = new DataTable();
                        adaptador.Fill(table);
                        bindingSource.DataSource = table;
                        datos.ItemsSource = bindingSource;
                    }
                    catch (SqlException ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
                    }
                    finally
                    {
                        conexion.Close();
                    }
                }

            }
        }

        public List<Object> recuperar_consulta<I>(string consulta)
        {


            using (SqlConnection conexion = new SqlConnection(contexto))
            {
                List<object> lista = new List<object>();
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                lista.Add(reader[i]);
                            }
                        }
                        conexion.Close();
                    }

                }

                return lista;
            }


        }
  
    }
}
