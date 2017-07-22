using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
   public class PerfilPrivilegio
    {
        [Key]
        public int PerfilPrivilegiosId { get; set; }
        public int PerfilId { get; set; }
        public int PrivilegioId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Privilegio Privilegio { get; set; }
    }
}
