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
        public void CrearEspecialidad(Especialidad especialidad)
        {
            _db.Especialidades.Add(especialidad);
            _db.SaveChanges();
        }

        //metodo para listar todos las especialidades
        public List<Especialidad> ListarEspecialidades()
        {
            List<Especialidad> lista = _db.Especialidades.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EliminarEspecialidad(string textBoxCode)
        {
            Especialidad especialidad = (from es in _db.Especialidades
                       where es.EspecialidadCode == textBoxCode
                       select es).FirstOrDefault();
            _db.Especialidades.Remove(especialidad);
            _db.SaveChanges();
        }

        public void ModificarEspecialidad(Especialidad especialidad, string textBoxCode)
        {
            Especialidad especial = (from es in _db.Especialidades
                       where es.EspecialidadCode == textBoxCode
                                     select es).FirstOrDefault();
            especial.Nombre = especialidad.Nombre;
           
            _db.Entry(especial).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}