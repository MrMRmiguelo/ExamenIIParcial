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
            if (TBUser.Text == string.Empty && TBNombre.Text == string.Empty && TBApellido.Text == string.Empty && TBPass.Text == string.Empty && TBCorreo.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos");
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
            if (TBUser.Text == string.Empty && TBNombre.Text == string.Empty && TBApellido.Text == string.Empty && TBPass.Text == string.Empty && TBCorreo.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos");
                TBUser.Focus();
            }
            else
            {
                try
                {
                    string nombre = "UPDATE Usuarios.Usuario SET nombre = @nombre";
                    string apellido = "UPDATE Usuarios.Usuario SET apellido = @apellido";
                    string correo = "UPDATE Usuarios.Usuario SET correo = @correo";

                    SqlCommand sqlCommand = new SqlCommand(nombre, sqlConnection);
                    SqlCommand sqlCommand1 = new SqlCommand(apellido, sqlConnection);
                    SqlCommand sqlCommand2 = new SqlCommand(correo, sqlConnection);

                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombre", TBUser.Text);
                    sqlCommand.Parameters.AddWithValue("@apellido", TBApellido.Text);
                    sqlCommand.Parameters.AddWithValue("@correo", TBCorreo.Text);
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

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (TBUser.Text == string.Empty && TBNombre.Text == string.Empty && TBApellido.Text == string.Empty && TBPass.Text == string.Empty && TBCorreo.Text == string.Empty)
            {
                MessageBox.Show("Debe completar todos los campos");
                TBUser.Focus();
            }
            else
            {
                try
                {
                    string query = "DELETE Usuarios.Usuario WHERE nombre = @nombre AND apellido = @apellido AND nombreusuario = @nombreusuario";
                    
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                   

                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@nombreusuario", TBUser.Text);
                    sqlCommand.Parameters.AddWithValue("@nombre", TBApellido.Text);
                    sqlCommand.Parameters.AddWithValue("@nombre", TBCorreo.Text);
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
       
    }
}

