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
using NoteControl.Source.DataAccess;
using System.Windows;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel;

namespace NoteControl
{
    /// <summary>
    /// Menu que alojara las paginas del sistema
    /// </summary>
    public partial class Menu : Window
    {

        MenuViewModel menuViewModel = new MenuViewModel(); 
        public Menu(Usuario usuario) //recibe todo los datos del usuario logeado
        {
           
            InitializeComponent();
            // listarPrivilegiosDelPerfil(usuario.Perfiles);
            base.DataContext = menuViewModel;
            //imagen de fondo para el menu
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/pizarron.png")));
        }

        private void btnMenuItemPerfiles(object sender, RoutedEventArgs e)
        {
            Main.Content = new MantPerfiles();
          
        }
        private void btnMenuItemCursos(object sender, RoutedEventArgs e)
        {
			Main.Content = new MantCurso();

		}
		private void btnMenuItemUsuarios(object sender, RoutedEventArgs e)
        {
            Main.Content = new MantUsuario();
        }

        private void btnMenuItemEspe(object sender, RoutedEventArgs e)
        {
            Main.Content = new MantEspecialidades();
        }
        private void btnMenuItemProfe(object sender, RoutedEventArgs e)
        {
            Main.Content = new MantProfe();
        }

		private void btnMenuItemNotasXEst(object sender, RoutedEventArgs e)
		{
			Main.Content = new RegXEstudiante();
		}
		private void btnMenuItemNotasXMat(object sender, RoutedEventArgs e)
		{
			Main.Content = new RegXMateria();
		}

		private void btnCAlumXCurso(object sender, RoutedEventArgs e)
		{
			Main.Content = new ConAlumXCurso();
		}
		private void btnCProfXCurso(object sender, RoutedEventArgs e)
		{
			Main.Content = new ConProfXCurso();
		}
		private void btnInforme(object sender, RoutedEventArgs e)
		{
			Main.Content = new InformeParcial();
		}

		private void btnSalir(object sender, RoutedEventArgs e)
		{

			if (MessageBox.Show("Seguro desea salir", "--.Salir.--", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
			{
				this.Close();
			}
			else
			{
			//Vuelve al sistema
			}

			//btnMenuItemNotasXMat


		}

		private void _Menu_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
