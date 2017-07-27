using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DAEspecialidades : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para agregar una especialidad
        public void crearEspecialidad(Especialidad especialidad)
        {
            _db.Especialidades.Add(especialidad);
            _db.SaveChanges();
        }

        //metodo para listar todos las especialidades
        public List<Especialidad> listarEspecialidades()
        {
            List<Especialidad> lista = _db.Especialidades.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}