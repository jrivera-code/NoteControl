using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
   public class Asignatura
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AsignaturaCode { get; set; }  
        public string Nombre { get; set; }
        public virtual List<AsignaturaProfesor> AsignaturaProfesores { get; set; }
        public virtual List<CursoAsignatura> CursoAsignaturas { get; set; }
    }
}
