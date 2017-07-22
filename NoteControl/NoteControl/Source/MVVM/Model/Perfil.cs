using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
    public class Perfil
    {
        [Key]
        public int PerfilId { get; set; }
        public string Nombre { get; set; }
        public virtual List<PerfilPrivilegio> PerfilesPrivilegios { get; set; }
    }
}
