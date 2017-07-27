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
    public class BLAlumnos {
        DAAlumnos _da = new DAAlumnos();
        //metodo para agregar un alumno
        public void crearAlumno(Alumno alum)
        {
            try
            {
                _da.crearAlumno(alum);
                MessageBox.Show("Alumno Creado Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //metodo para listar todos los alumnos
        public List<Alumno> listarAlumnos()
        {
            try
            {
                return _da.listarAlumnos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //metodo para listar todos los alumnos por curso
        public List<Alumno> listarAlumnosPorCurso(string cursoCode)
        {
            try
            {
                return _da.listarAlumnosPorCursos(cursoCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
   
}
