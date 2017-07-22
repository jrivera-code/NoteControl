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
using System.Configuration;
using System.Data.SqlClient;
using NoteControl.Source.DataAccess;

namespace NoteControl
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            using (var db = new NoteControlContext()) {

                var listaUsuarios = db.Usuarios.ToList();
            }
                
            InitializeComponent();
        }


        
        private void btnAceptar(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void btnsalir(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias!");
            Close();
        }
    }
}
