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
     
        private BLLogin _blLogin = new BLLogin();
        public MainWindow()
        {
            //crea la base de datos si no existe
            if (!_blLogin.DataBaseExist())
            {
                _blLogin.CreateDataBase();
            }
            InitializeComponent();
            image.Source = new BitmapImage(new Uri("pack://application:,,,/NoteControl;component/Source/MVVM/View/Img/notas.png"));
        }


        /// <summary>
        /// Boton aceptar, ingreso a sistema
        /// </summary>
        private void BtnAceptar(object sender, RoutedEventArgs e)
        {
            //pregunta su el usuario existe
            if (_blLogin.UserExist(txtUsuario.Text, txtPass.Password))
            {
                Usuario user = _blLogin.GetUser();
                //pasa el usuario encontrado al contructor del menu
                switch (user.Estado) {
                    case 0:
                        MessageBox.Show("Su cuenta de usuario esta suspendida");
                        break;
                    case 1:
                        Menu menu = new Menu(_blLogin.GetUser());
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

        private void BtnSalir(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias!");
            Close();
        }
    }
}
