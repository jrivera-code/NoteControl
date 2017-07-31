﻿using System;
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
using NoteControl;
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel;

namespace NoteControl
{
	/// <summary>
	/// </summary>
	public partial class IngNotas : Page
	{
        IngNotasViewModel ingNotasAsigViewModel;
        public IngNotas(Usuario userLogeado)
		{
			InitializeComponent();
            ingNotasAsigViewModel = new IngNotasViewModel(userLogeado);
            this.DataContext = ingNotasAsigViewModel;

        }
    }
}
