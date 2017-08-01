using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DACursos : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para agregar un curso
        public void CrearCurso(Curso curso,int profesorJefe)
        {
           Profesor prof = _db.Profesores.Where(p => p.Rut == profesorJefe).FirstOrDefault();
            curso.Profesor = prof;
            _db.Cursos.Add(curso);
            _db.SaveChanges();
        }

        //metodo para listar todos las Cursos
        public List<Curso> ListarCursos()
        {
            List<Curso> lista = _db.Cursos.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ModificarCurso(Curso curso, string textBoxCodeCurso,int newProfe)
        {
           Profesor p = _db.Profesores.Where(pr => pr.Rut == newProfe).FirstOrDefault();

            Curso c = (from cur in _db.Cursos
                    where cur.CursoCode == textBoxCodeCurso
                    select cur).FirstOrDefault();
            c.Nombre = curso.Nombre;
            c.Descripcion = curso.Descripcion;
            c.Profesor = p;
             _db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void EliminarCurso(string textBoxCodeCurso)
        {
            Curso c = (from cur in _db.Cursos
                       where cur.CursoCode == textBoxCodeCurso
                       select cur).FirstOrDefault();
            _db.Cursos.Remove(c);
            _db.SaveChanges();
        }

        public List<Curso> ListarCursosPorProfesor(int rut)
        {
            List<Curso> list = (from cur in _db.Cursos
                                join cpa in _db.CursoProfeAsignaturas
                                on cur.CursoCode equals cpa.CursoCode
                                join prof in _db.Profesores
                                on cpa.Rut equals prof.Rut
                       where cpa.Rut == rut
                                select cur).ToList();
            string preCodeCurso = "";
            List<Curso> cursos = new List<Curso>();
            list.ForEach(e => {
                if (e.CursoCode != preCodeCurso)
                    cursos.Add(e);
                preCodeCurso = e.CursoCode;
            });
            return cursos;
        }
    }
}