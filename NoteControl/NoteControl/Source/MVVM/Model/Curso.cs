using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
   public class Curso
    {

        [Key] [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CursoCode { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual List<CursoProfeAsignatura> CursoAsignaturas { get; set; }
        public virtual List<Alumno> Alumnos { get; set; }
    }
}
