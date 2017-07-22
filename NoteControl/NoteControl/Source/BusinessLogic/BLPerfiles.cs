using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;

namespace NoteControl.Source.BusinessLogic
{
  
    public class BLPerfiles : IDisposable
    {
        DAPerfiles _da = new DAPerfiles();
        //metodo para agregar un nuevo perfil
        public void crearPerfil(Perfil perfil)
        {
            try {
                _da.crearPerfil(perfil);
            } catch (Exception ex) {
                throw;
            }
          
        }

        //metodo para listar todos los perfil
        public List<Perfil> listarPerfiles()
        {
            try
            {
               return _da.listarPerfiles();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void Dispose()
        {
            _da.Dispose();
        }
    }
}
