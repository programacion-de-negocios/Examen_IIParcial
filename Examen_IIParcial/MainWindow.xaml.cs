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
        }

        //METODO PARA MOSTRAR A LAS PERSONAS
        private void MostrarPersonas()
        {
            try
            {
                string query = "SELECT * FROM Zoo.Animal";
                SqlDataAdapter adapter = new SqlDataAdapter(query, SqlCon);
                using (adapter)
                {
                    DataTable TablaAnimales = new DataTable();
                    adapter.Fill(TablaAnimales);
                    LbAnimales.DisplayMemberPath = "Nombre";
                    LbAnimales.SelectedValuePath = "Id_Animal";
                    LbAnimales.ItemsSource = TablaAnimales.DefaultView;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
