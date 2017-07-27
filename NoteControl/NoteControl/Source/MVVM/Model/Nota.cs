using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class Nota
    {

        [Key]
        public int NotaId { get; set; }
        public string Calificacion { get; set; }
        public virtual List<AlumnoNotaAsignatura> AlumnoNotaAsignatura { get; set; }
    }

}
