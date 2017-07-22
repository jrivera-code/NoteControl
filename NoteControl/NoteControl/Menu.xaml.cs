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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Data.SqlClient;

namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para Contenedor.xaml
    /// </summary>
    public partial class Menu : Window
    {

        SqlDataReader readerUsuario;
        public Menu(SqlDataReader reader) //trae todo los datos del usuario logeado
        {
            this.readerUsuario = reader;
            //consultar los privilegios del usuario
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
    }
}
