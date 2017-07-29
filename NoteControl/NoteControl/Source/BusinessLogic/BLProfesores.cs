using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteControl.Source.BusinessLogic
{
   public class BLProfesores
    {
        DAProfesores _da = new DAProfesores();
        //metodo para agregar un profesor
        public void CrearProfesor(Profesor profe)
        {
            try
            {
                _da.CrearProfesor(profe);
                MessageBox.Show("Profesor Creado Exitosamente!");
            }
            catch 
            {
                throw;
            }

        }
        //metodo para listar todos los profesores
        public List<Profesor> ListarProfesores()
        {
            try
            {
                return _da.ListarProfesores();
            }
            catch 
            {
                throw;
            }
        }

        public void EliminarProfesor(string textBoxRut)
        {
            try
            {
                _da.EliminarProfesor(textBoxRut);
            }
            catch 
            {
                throw;
            }
        }

        public void ModificarProfesor(Profesor profesor, string textBoxRut)
        {
            try
            {
                _da.ModificarProfesor(profesor, textBoxRut);
                MessageBox.Show("El profesor fue eliminado");
            }
            catch 
            {
                throw;
            }
        }
    }
}
