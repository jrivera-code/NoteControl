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
        public void AgregarNuevaNota(string calificacion, string asignaturaCode, string rut)
        {
            _db.AlumnoNotaAsignaturas.Add(new AlumnoNotaAsignatura() {
                AsignaturaCode = asignaturaCode,
                Calificacion = double.Parse(calificacion),
                Rut = int.Parse(rut)
            });
            _db.SaveChanges();
        }
    }
}
