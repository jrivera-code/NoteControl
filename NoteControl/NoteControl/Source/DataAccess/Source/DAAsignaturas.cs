using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAAsignaturas : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para agregar una asignatura
        public void CrearAsignatura(Asignatura asignatura)
        {
            _db.Asignaturas.Add(asignatura);
            _db.SaveChanges();
        }

        //metodo para listar todos las asignaturas
        public List<Asignatura> ListarAsignaturas()
        {
            List<Asignatura> lista = _db.Asignaturas.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}