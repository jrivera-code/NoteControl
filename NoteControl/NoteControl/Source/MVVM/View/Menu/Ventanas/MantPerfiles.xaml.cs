using NoteControl.Source.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NoteControl.Source.MVVM.Model;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NoteControl.Source.MVVM.ViewModel;

namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para MantPerfiles.xaml
    /// </summary>
    public partial class MantPerfiles : Page
    {
        MantPerfilesViewModel mantPerfilesViewModel = new MantPerfilesViewModel();
        public MantPerfiles()
        {
            InitializeComponent();
            base.DataContext = mantPerfilesViewModel;
        }
           public ICommand ButtonCommand { get; set; }

       
        private void MainButtonClick(object sender)
        {
            MessageBox.Show(sender.ToString());            
        }
    /*
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
          string perfil =  txtPerfil.Text;
          BLPerfiles blPerfiles = new BLPerfiles();
          blPerfiles.crearPerfil(new Perfil() {Nombre = perfil });
        }
       */
    }
}
