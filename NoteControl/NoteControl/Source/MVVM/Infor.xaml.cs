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
using NoteControl.Source.MVVM.Model;
using NoteControl.Source.MVVM.ViewModel;


namespace NoteControl.Source.MVVM
{
	/// <summary>
	/// Lógica de interacción para Infor.xaml
	/// </summary>
	public partial class Infor : Page
	{

		public Infor()
		{
			InitializeComponent();
		}
		
		private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
