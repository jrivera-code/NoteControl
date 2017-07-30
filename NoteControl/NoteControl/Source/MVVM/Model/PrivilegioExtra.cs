using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class PrivilegioExtra
    {
        [Key]
        public int PrivilegioExtraId { get; set; }
        public int Rut { get; set; }
        public int PrivilegioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Privilegio Privilegio { get; set; }
    }
}
