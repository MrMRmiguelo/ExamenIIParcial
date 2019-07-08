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
//NAMESPACE NECESARIOS
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace ExamenIIParcial___Programacion_de_Negocios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            SqlConnection sqlConnection = new SqlConnection();
            SmtpClient correo = new SmtpClient();
        }
        private void MostrarUsers()
        {
            
           
            
                try
                {
                    string query = "SELECT * FROM Usuarios.Usuario";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                    using (sqlDataAdapter)
                    {
                        DataTable Usuarios = new DataTable();
                        sqlDataAdapter.Fill(Usuarios);

                        lbUsuarios.DisplayMemberPath = "nombre";
                        lbUsuarios.SelectedValuePath = "id";
                        lbUsuarios.ItemsSource = Usuarios.DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
        }


        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (TBUser.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un nombre de usuario");
                TBUser.Focus();
            }
            else
            {
                try
                {
                    string query = "INSERT INTO Usuarios.Usuario(nombre) VALUES(@nombre)";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", TBUser.Text);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    sqlConnection.Close();
                    MostrarUsers();
                }

            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
       
    }
}

