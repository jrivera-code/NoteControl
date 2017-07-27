using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class AsignaturaProfesor
    {
        [Key]
        public int AsignaturaProfesorId { get; set; }
        public string AsignaturaCode { get; set; }
        public int Rut { get; set; }
        public virtual Asignatura Asignaturas { get; set; }
        public virtual Profesor Profesores { get; set; }
    }
}
