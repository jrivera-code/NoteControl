using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.BusinessLogic
{
    public class BLPrivilegiosExtra
    {
        DAPrivilegiosExtra _da = new DAPrivilegiosExtra();
        
        public List<PrivilegioExtra> ListarPrivilegiosExtra(Usuario user) {
            
            try {
                return _da.ListarPrivilegiosExtra(user);
            } catch { throw; }
        }

        public void CrearRelacionUsuarioPrivilegioExtras(Usuario user, int[] indexPrivilegio)
        {
            try
            {
                _da.CrearRelacionUsuarioPrivilegioExtras(user,indexPrivilegio);
            }
            catch { throw; }
        }
        
        public void RemoverTodasLasRelaciones(Usuario user)
        {
            try
            {
                _da.RemoverTodasLasRelaciones(user);
            }
            catch { throw; }
        }
    }
}
