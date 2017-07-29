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
using NoteControl.Source.BusinessLogic;

namespace NoteControl
{

    public partial class MainWindow : Window
    {
     
        BLLogin blLogin = new BLLogin();
        public MainWindow()
        {
            //crea la base de datos si no existe
            if (!blLogin.DataBaseExist())
            {
                blLogin.CreateDataBase();
            }
            InitializeComponent();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/notas.png"));
        }


        /// <summary>
        /// Boton aceptar, ingreso a sistema
        /// </summary>
        private void btnAceptar(object sender, RoutedEventArgs e)
        {
            //pregunta su el usuario existe
            if (blLogin.userExist(txtUsuario.Text, txtPass.Password))
            {
                Usuario user = blLogin.getUser();
                //pasa el usuario encontrado al contructor del menu
                switch (user.Estado) {
                    case 0:
                        MessageBox.Show("Su cuenta de usuario esta suspendida");
                        break;
                    case 1:
                        Menu menu = new Menu(blLogin.getUser());
                        menu.Show();
                        this.Close();
                        break;
                }
            }
            else
            {
                MessageBox.Show("El usuario o la password son incorrectas");

            }


        }

        private void btnsalir(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias!");
            Close();
        }
    }
}
