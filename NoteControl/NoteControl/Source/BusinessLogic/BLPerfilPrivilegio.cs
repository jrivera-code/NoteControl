using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteControl.Source.BusinessLogic
{
   public class BLPerfilPrivilegio
    {
        DAPerfilPrivilegio _da = new DAPerfilPrivilegio();
        public void CrearRelacionPerfilPrivilegio(Perfil perfil, int indexPrivilegio)
        {
            try
            {
               
                _da.crearRelacionPerfilPrivilegio(perfil, indexPrivilegio);
              
            }
            catch 
            {
                throw;
            }

        }


    }
}
