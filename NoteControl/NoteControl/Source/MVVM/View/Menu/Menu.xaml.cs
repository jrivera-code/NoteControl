using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Data.SqlClient;
using NoteControl.DataAccess;
using System.Windows;


namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para Contenedor.xaml
    /// </summary>
    public partial class Menu : Window
    {

        SqlDataReader readerUsuario;
        Conexion conexion;
        public Menu(SqlDataReader reader) //trae todo los datos del usuario logeado
        {
            //crea una instancia de la conexion
            conexion = new Conexion();
            this.readerUsuario = reader;
            string perfil = readerUsuario["Id_Perfil"].ToString();
            //consultar los privilegios del usuario
            string query = "SELECT Nombre, Privilegios.Id_Privilegios FROM RelPerfPrivi INNER JOIN" +
                " Privilegios ON Privilegios.Id_Privilegios = RelPerfPrivi.Id_Privilegios " +
                "INNER JOIN Perfiles ON Perfiles.Id_Perfil = RelPerfPrivi.Id_Perfil" +
                " WHERE Perfiles.Id_Perfil = " + perfil;
            SqlDataReader privilegiosReader = queryToReader(query);
            while (privilegiosReader.Read()) {
                string id = privilegiosReader["Id_Privilegios"].ToString(),
                    nombrePrivilegio = privilegiosReader["Nombre"].ToString();
            }
            conexion.Desconectar();
            InitializeComponent();
        }

        private void btnMenuItemPerfiles(object sender, RoutedEventArgs e)
        {
            MantPerfiles mp = new MantPerfiles();
            frmMenu.Navigate(mp);
        }
        private void btnMenuItemCursos(object sender, RoutedEventArgs e)
        {
            MantPerfiles mp = new MantPerfiles();
            frmMenu.Navigate(mp);
        }
        private void btnMenuItemUsuarios(object sender, RoutedEventArgs e)
        {
            MantUsuario musu = new MantUsuario();
            frmMenu.Navigate(musu);
        }

        private void frmMenu_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private SqlDataReader queryToReader(string query) {
            SqlCommand cmd;
            SqlDataReader reader = null;
            try
            {
                conexion.Conectar();
                cmd = new SqlCommand();
                cmd.Connection = conexion.getConexion();
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return reader;
        }
    }
}
