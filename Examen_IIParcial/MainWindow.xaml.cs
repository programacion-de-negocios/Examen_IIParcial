using System;
using System.Collections.Generic;
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

//USANDO LOS NAMESPACES NECESARIOS
using System.Data;
using System.Data.SqlClient;

namespace Examen_IIParcial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection SqlCon;
        public MainWindow()
        {
            InitializeComponent();
            string ConnectionString = Conexion.Cn;
            SqlCon = new SqlConnection(ConnectionString);
            MostrarPersonas();
            Mostrar_Tipo_Usuario();
            
        }

        //METODO PARA MOSTRAR A LAS PERSONAS
        private void MostrarPersonas()
        {
            try
            {
                string query = "SELECT * FROM Usuarios.Persona";
                SqlDataAdapter adapter = new SqlDataAdapter(query, SqlCon);
                using (adapter)
                {
                    DataTable TablaPersona = new DataTable();
                    adapter.Fill(TablaPersona);
                    lbpersona.DisplayMemberPath = "Nombre";
                    lbpersona.SelectedValuePath = "Id_Persona";
                    lbpersona.ItemsSource = TablaPersona.DefaultView;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
        }

        private void Agregar_Persona(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = @"INSERT INTO Usuarios.Persona (Nombre,Apellido) VALUES (@nom,@ape)";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlCon.Open();
                SqlCmd.Parameters.AddWithValue("@nom", txtnombre.Text);
                SqlCmd.Parameters.AddWithValue("@ape", txtnombre.Text);
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlCon.Close();
                MostrarPersonas();
            }
        }

        private void Eliminar_Persona(object sender,RoutedEventArgs e)
        {
            try
            {
                string query = @"DELETE FROM Usuarios.Persona WHERE Id_Persona = @id";
                SqlCommand SqlCmd = new SqlCommand(query, SqlCon);

                SqlCon.Open();
                SqlCmd.Parameters.AddWithValue("@id",lbpersona.SelectedValue);
                SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SqlCon.Close();
                MostrarPersonas();
            }
        }

        private void Actualizar_Persona(object sender,RoutedEventArgs e)
        {

        }
        private void Mostrar_Tipo_Usuario()
        {
            try
            {
                string query = "SELECT * FROM Usuarios.Tipo_Usuario";
                SqlDataAdapter adapter = new SqlDataAdapter(query, SqlCon);
                using (adapter)
                {
                    DataTable TablaPersona = new DataTable();
                    adapter.Fill(TablaPersona);
                    lbtipousuario.DisplayMemberPath = "Tipo_Usuario";
                    lbtipousuario.SelectedValuePath = "Id_Tipo_Usuario";
                    lbtipousuario.ItemsSource = TablaPersona.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        
    }
}
