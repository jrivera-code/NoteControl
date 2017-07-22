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
    /// Lógica de interacción para Contenedor.xaml
    /// </summary>
    public partial class Menu : Window
    {

    
        public Menu(Usuario usuario) //recibe todo los datos del usuario logeado
        {
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
