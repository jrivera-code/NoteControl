using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class Profesor
    {

        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<CursoProfeAsignatura> CursoProfeAsignaturas { get; set; }
    }
}
