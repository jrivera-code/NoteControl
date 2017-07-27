using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
   public class DAAlumnos
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para agregar un alumno
        public void crearAlumno(Alumno alumno)
        {
            _db.Alumnos.Add(alumno);
            _db.SaveChanges();
        }

        //metodo para listar todos los alumnos
        public List<Alumno> listarAlumnos()
        {
            List<Alumno> lista = _db.Alumnos.ToList();
            return lista;
        }

        public List<Alumno> listarAlumnosPorCursos(string codeCurso)
        {
            List<Alumno> list = new List<Alumno>();
            var query = from alumnos in _db.Alumnos
                        join cursos in _db.Cursos on alumnos.CursoCode
                        equals cursos.CursoCode
                        where cursos.CursoCode == codeCurso
                        select alumnos;
            foreach (Alumno alum in query)
            {
                list.Add(alum);
            }
            return list;
        }
    }
}
