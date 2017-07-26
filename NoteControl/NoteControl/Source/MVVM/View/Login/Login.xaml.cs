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
            if (!db.Database.Exists()) {
                string[] privilegios = { "Mantenedor de Perfiles", "Mantenedor de Usuarios","Mantenedor de Cursos",
                "Mantenedor de Profesores","Mantenedor de Especialidades","Ingresar Notas por Asignatura",
                "Ingresar Notas por Estudiante","Consulta de Alumnos por Cursos","Consulta de Profesores por Cursos",
                "Generacion de Informes"};
                db.Database.Create();
                 Perfil perfil = new Perfil() { Nombre = "Administrador" };
                db.Perfiles.Add(perfil);
                for (int i =0;i<privilegios.Length;i++) {
                 Privilegio privilegio = new Privilegio() { Nombre = privilegios[i] };
                    db.Privilegios.Add(privilegio);
                    db.SaveChanges();
                    db.PerfilesPrivilegios.Add(new PerfilPrivilegio() { PrivilegioId = i + 1, PerfilId = 1 });
                }
                db.Usuarios.Add(new Usuario() { Nombre = "jmolina", Clave = "1234", Estado = 1, Perfiles = perfil });
                db.SaveChanges();
            }

            InitializeComponent();
        }


        /// <summary>
        /// Boton aceptar, ingreso a sistema
        /// </summary>
        private void btnAceptar(object sender, RoutedEventArgs e)
        {
            //pregunta su el usuario existe
            if (blLogin.userExist(txtUsuario.Text,txtPass.Password))
            {
                //pasa el usuario encontrado al contructor del menu
                Menu menu = new Menu(blLogin.getUser());
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
