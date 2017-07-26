using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.BusinessLogic
{
   public class BLUsuarios
    {
        DAUsuarios _da = new DAUsuarios();
        //metodo para listar todos los usuarios
        public List<Usuario> listarUsuarios()
        {
            try
            {
                return _da.listarUsuarios();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
