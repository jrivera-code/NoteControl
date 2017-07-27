using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class CursoAsignatura
    {
        [Key]
        public int CursoAsignaturaId { get; set; }
        public string AsignaturaCode { get; set; }
        public string CursoCode { get; set; }
        public virtual Asignatura Asignaturas { get; set; }
        public virtual Curso Cursos { get; set; }
    }
}
