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
        public void CrearCurso(Curso curso)
        {
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

        public void ModificarCurso(Curso curso, string textBoxCodeCurso)
        {
            Curso c = (from cur in _db.Cursos
                    where cur.CursoCode == textBoxCodeCurso
                    select cur).FirstOrDefault();
            c.Nombre = curso.Nombre;
            c.Descripcion = curso.Descripcion;
             _db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void EliminarCurso(string textBoxCodeCurso)
        {
            Curso c = (from cur in _db.Cursos
                       where cur.CursoCode == textBoxCodeCurso
                       select cur).FirstOrDefault();
            _db.Cursos.Remove(c).Alumnos.Clear();
            _db.SaveChanges();
        }
    }
}