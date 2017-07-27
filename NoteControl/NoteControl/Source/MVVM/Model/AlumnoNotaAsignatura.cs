using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class AlumnoNotaAsignatura
    {
        [Key]
        public int AlumnoNotaAsignaturaId { get; set; }
        public int NotaId { get; set; }
        public string AsignaturaCode { get; set; }
        public int Rut { get; set; }
        public virtual Nota Nota { get; set; }
        public virtual Asignatura Asignatura { get; set; }
        public virtual Alumno Alumno { get; set; }
    }
}
