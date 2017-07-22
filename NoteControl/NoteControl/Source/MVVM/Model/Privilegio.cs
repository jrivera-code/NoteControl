using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.MVVM.Model
{
   public class Privilegio
    {
        public int PrivilegioId { get; set; }
        public int Nombre { get; set; }
        public virtual List<PerfilPrivilegio> PerfilesPrivilegios { get; set; }
    }
}
