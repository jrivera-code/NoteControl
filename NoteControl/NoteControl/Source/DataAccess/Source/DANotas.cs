using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DANotas
    {
        private NoteControlContext _db = new NoteControlContext();
        public void AgregarNuevaNota(float calificacion, string asignaturaCode, int rut,int numeroNota)
        {
            
            //busca si ya existe
            var alumNotAsig = (from ana in _db.AlumnoNotaAsignaturas
                       where ana.NumeroNota == numeroNota &&
                       ana.AsignaturaCode == asignaturaCode &&
                       ana.Rut == rut
                       select ana).FirstOrDefault();
            if (alumNotAsig == null)
            {
                //si la nota no existe
                _db.AlumnoNotaAsignaturas.Add(new AlumnoNotaAsignatura()
                {
                    AsignaturaCode = asignaturaCode,
                    Calificacion = calificacion,
                    Rut = rut,
                    NumeroNota = numeroNota
                });
                _db.SaveChanges();
            }
            else {
                //si la nota ya existe
                alumNotAsig.Calificacion = calificacion;
                _db.Entry(alumNotAsig).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }
            
        }
    }
}
