using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class EspecialidadProfesor
    {
        [Key]
        public int EspecialidadProfesorId { get; set; }
        public int Rut { get; set; }
        public string EspecialidadCode { get; set; }
        public virtual Profesor Profesores { get; set; }
        public virtual Especialidad Especialidades { get; set; }
    }
}
