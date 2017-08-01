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
        public void CrearAlumno(Alumno alumno)
        {
            _db.Alumnos.Add(alumno);
            _db.SaveChanges();
        }

        //metodo para listar todos los alumnos
        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> lista = _db.Alumnos.ToList();
            return lista;
        }

        public List<Alumno> ListarAlumnosPorCursos(string codeCurso)
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

        public List<Alumno> ListarAlumnosPorCursoYAsignatura(string asigCode, string cursoCode)
        {
            List<Alumno> list = new List<Alumno>();
            var li = (from alum in _db.Alumnos join
                      curso in _db.Cursos on
                      alum.CursoCode equals curso.CursoCode
                      join cpa in _db.CursoProfeAsignaturas
                         on curso.CursoCode equals cpa.CursoCode
                      join asig in _db.Asignaturas
                        on cpa.AsignaturaCode equals asig.AsignaturaCode
                      join profe in _db.Profesores
                        on cpa.Rut equals profe.Rut
                      where asig.AsignaturaCode == asigCode &&
                      curso.CursoCode == cursoCode
                      select alum).ToList();

            foreach (Alumno a in li)
            {
                list.Add(a);
            }
            return list;
        }
    }
}
