using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
   public class Alumno
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rut { get; set; }  
        public string Nombre { get; set; }
        public virtual List<AlumnoNotaAsignatura> AlumnoNotaAsignaturas { get; set; }
    }
}
