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
        MenuViewModel menuViewModel;
        public Menu(Usuario usuario) //recibe todo los datos del usuario logeado
        {
            menuViewModel = new MenuViewModel(usuario);
            InitializeComponent();
            //imagen de fondo para el menu
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/background.png")));
            DataContext = menuViewModel;
        }

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
