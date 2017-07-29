using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteControl.Source.DataAccess.Source;
using NoteControl.Source.MVVM.Model;
using System.Windows.Forms;

namespace NoteControl.Source.BusinessLogic
{
  
    public class BLPerfiles : IDisposable
    {
        DAPerfiles _da = new DAPerfiles();
        //metodo para agregar un nuevo perfil
        public void CrearPerfil(Perfil perfil)
        {
            try {
                _da.CrearPerfil(perfil);
                MessageBox.Show("Perfil Creado Exitosamente!");
            } catch  {
                throw;
            }
          
        }
        //metodo para listar todos los perfil
        public List<Privilegio> ListarPrivilegiosDelPerfil(Perfil perfil)
        {
            try
            {
                return _da.ListarPrivilegiosDelPerfil(perfil);
            }
            catch 
            {
                throw;
            }
        }
        //metodo para listar todos los perfil
        public List<Perfil> ListarPerfiles()
        {
            try
            {
               return _da.ListarPerfiles();
            }
            catch 
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
