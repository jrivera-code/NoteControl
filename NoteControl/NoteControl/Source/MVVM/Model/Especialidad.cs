using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class Especialidad
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EspecialidadCode { get; set; }
        public string Nombre { get; set; }
    }
}
