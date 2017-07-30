using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class Usuario
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rut { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public virtual Perfil Perfiles { get; set; }
        public virtual List<Profesor> Profesores { get; set; }
        public virtual List<PrivilegioExtra> PrivilegioExtras { get; set; }
        public int Estado { get; set; }
    }
}
