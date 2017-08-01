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
        public void CrearAlumno(Alumno alum)
        {
            try
            {
                _da.CrearAlumno(alum);
                MessageBox.Show("Alumno Creado Exitosamente!");
            }
            catch 
            {
                throw;
            }

        }
        //metodo para listar todos los alumnos
        public List<Alumno> ListarAlumnos()
        {
            try
            {
                return _da.ListarAlumnos();
            }
            catch
            {
                throw;
            }
        }
        //metodo para listar todos los alumnos por curso
        public List<Alumno> ListarAlumnosPorCurso(string cursoCode)
        {
            try
            {
                return _da.ListarAlumnosPorCursos(cursoCode);
            }
            catch
            {
                throw;
            }
        }

        public List<Alumno> ListarAlumnosPorCursoYAsignatura(string asig, string curso)
        {
            try
            {
                return _da.ListarAlumnosPorCursoYAsignatura(asig, curso);
            }
            catch
            {
                throw;
            }
        }
    }
   
}
