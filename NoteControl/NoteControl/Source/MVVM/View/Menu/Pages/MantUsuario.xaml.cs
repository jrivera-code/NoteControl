﻿using NoteControl.Source.MVVM.ViewModel;
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

namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para MantUsuario.xaml
    /// </summary>
    public partial class MantUsuario : Page
    {
        MantUsuariosViewModel mantUsuariosViewModel = new MantUsuariosViewModel();
        public MantUsuario()
        {
            InitializeComponent();
            this.DataContext = mantUsuariosViewModel;
        }

       
    }
}
