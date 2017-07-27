using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAProfesores : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para agregar un profesor
        public void crearProfesor(Profesor profe)
        {
            _db.Profesores.Add(profe);
            _db.SaveChanges();
        }

        //metodo para listar todos los profesores
        public List<Profesor> listarProfesores()
        {
            List<Profesor> lista = _db.Profesores.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}