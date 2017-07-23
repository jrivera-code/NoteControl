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
using NoteControl.Source.MVVM.Model;

namespace NoteControl
{
    
    public partial class MainWindow : Window
    {
        NoteControlContext db = new NoteControlContext();
        public MainWindow()
        {
            //crea la base de datos si no existe
            db.Database.CreateIfNotExists();

            InitializeComponent();
        }


        /// <summary>
        /// Boton aceptar, ingreso a sistema
        /// </summary>
        private void btnAceptar(object sender, RoutedEventArgs e)
        {
            //trae el usuario que cumpla con la condicion
            var usuarios = from user in db.Usuarios
                                       where (user.Nombre == txtUsuario.Text
                                       && user.Clave == txtPass.Password)
                                       select user;
        
            if (usuarios.Count() != 0)
            {
                Usuario usuarioEncontrado = usuarios.First();

                Menu menu = new Menu(usuarioEncontrado);
               
                menu.Show();
                this.Close();
            }
            else {
                MessageBox.Show("El usuario o la password son incorrectas");
              
            }

           
        }

        private void btnsalir(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias!");
            Close();
        }

        private void txtPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Set to no text.
           // txtPass.Text = "";
            // The password character is an asterisk.
            //txtPass.PasswordChar = '*';
           
        }
    }
}
