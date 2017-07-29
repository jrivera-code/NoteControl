using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.BusinessLogic
{
    public class BLPrivilegios
    {
        DAPrivilegios _da = new DAPrivilegios();
        //metodo para listar todos los privilegios
        public List<Privilegio> ListarPrivilegios()
        {
            try
            {
                return _da.ListarPrivilegios();
            }
            catch
            {
                throw;
            }
        }
    }
}
