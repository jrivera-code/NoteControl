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
        NoteControlContext db = new NoteControlContext();
        BLLogin blLogin = new BLLogin();
        public MainWindow()
        {
            //crea la base de datos si no existe
            if (!db.Database.Exists())
            {
                string[] privilegios = { "Mantenedor de Perfiles", "Mantenedor de Usuarios","Mantenedor de Cursos",
                "Mantenedor de Profesores","Mantenedor de Especialidades","Ingresar Notas por Asignatura",
                "Ingresar Notas por Estudiante","Consulta de Alumnos por Cursos","Consulta de Profesores por Cursos",
                "Generacion de Informes"};
                string[] asignaturas = {"Artes Visuales",
                            "Ciencias Naturales",
                            "Educación Física y Salud",
                            "Historia", "Geografía y Ciencias Sociales",
                            "Inglés",
                            "Lenguaje y Comunicación",
                            "Matemática",
                            "Música" };
                string[] nombres = { "Matias", "Felipe", "Camilo", "Ricardo", "Emilio", "Cesar", "Francisco", "Pablo" };
                string[] apellidos = { "Rivera", "Cardenas", "Jaramillo", "Fernandez", "Sanchez", "Vidal", "Dias", "Bravo" };
                db.Database.Create();
                
                    Curso curso = new Curso() { CursoCode = "A10", Nombre = "Primero Basico", Descripcion = "Conocimiento de sí mismo e ingreso al mundo de la lectura y escritura" };
                db.Cursos.Add(curso);
                for (int i = 0; i < nombres.Length; i++)
                {
                    Alumno alum = new Alumno() {Rut = 1813035+i , Nombre = nombres[i],Apellido = apellidos[i],Curso= curso };
                    db.Alumnos.Add(alum);
                    db.SaveChanges();
                }
                Perfil perfil = new Perfil() { Nombre = "Administrador" };
                db.Perfiles.Add(perfil);
                for (int i = 0; i < privilegios.Length; i++)
                {
                    Privilegio privilegio = new Privilegio() { Nombre = privilegios[i] };
                    db.Privilegios.Add(privilegio);
                    db.SaveChanges();
                    db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i + 1, PerfilId = 1 });
                }
                for (int i = 0; i < asignaturas.Length; i++)
                {
                    Asignatura asig = new Asignatura() { AsignaturaCode = i.ToString(), Nombre = asignaturas[i] };
                    db.Asignaturas.Add(asig);
                    db.SaveChanges();
                }
                db.Usuarios.Add(new Usuario() { Nombre = "JMOLINA", Clave = "1234", Estado = 1, Perfiles = perfil });
                db.SaveChanges();
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

        private void txtPass_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Set to no text.
            // txtPass.Text = "";
            // The password character is an asterisk.
            //txtPass.PasswordChar = '*';

        }
    }
}
