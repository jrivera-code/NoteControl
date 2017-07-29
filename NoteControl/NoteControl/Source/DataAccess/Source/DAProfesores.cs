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
        public void CrearProfesor(Profesor profe)
        {
            _db.Profesores.Add(profe);
            _db.SaveChanges();
        }

        //metodo para listar todos los profesores
        public List<Profesor> ListarProfesores()
        {
            List<Profesor> lista = _db.Profesores.ToList();
            return lista;
        }
       

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void EliminarProfesor(string textBoxRut)
        {
            Profesor prof = (from p in _db.Profesores
                       where p.Rut.ToString() == textBoxRut
                       select p).FirstOrDefault();
            _db.Profesores.Remove(prof);
            _db.SaveChanges();
        }

        public void ModificarProfesor(Profesor profesor, string textBoxRut)
        {
            Profesor prof = (from p in _db.Profesores
                       where p.Rut == int.Parse(textBoxRut)
                       select p).FirstOrDefault();
            prof.Nombre = profesor.Nombre;
            prof.Apellido = profesor.Apellido;
            _db.Entry(prof).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}