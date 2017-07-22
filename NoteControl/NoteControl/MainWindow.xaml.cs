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
using System.Configuration;
using System.Data.SqlClient;

namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        public MainWindow()
        {
       conn = new SqlConnection(@"Data Source=DESKTOP-16VNQA4;Initial Catalog=Note_Control;Integrated Security=True");
       InitializeComponent();
        }


        
        private void btnAceptar(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string pass = txtPass.Password;
            if (usuario != "" && pass != "")
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Usuarios WHERE Nick = '"+usuario+"' AND Clave = '"+pass+"'";
                cmd.Connection = conn;
                var reader = cmd.ExecuteReader();
              
                if (reader.Read())
                {
                    Menu menu = new Menu(reader);
                    menu.Show();
                }
                else {
                    MessageBox.Show("Usuario o Contraseña no existen");
                }
               
            }
            else {
                MessageBox.Show("Complete los Campos");
            }
            conn.Close();
        }

        private void btnsalir(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Gracias!");
            Close();
        }
    }
}
