﻿using System;
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


namespace NoteControl
{
    /// <summary>
    /// Menu que alojara las paginas del sistema
    /// </summary>
    public partial class Menu : Window
    {

    
        public Menu(Usuario usuario) //recibe todo los datos del usuario logeado
        {
            InitializeComponent();
            //imagen de fondo para el menu
            this.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/fondo.jpg")));
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


			
		}
	}
}
