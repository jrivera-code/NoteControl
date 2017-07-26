using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
   public class DAUsuarios : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();


        //metodo para listar todos los usuarios
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> lista = _db.Usuarios.ToList();
            return lista;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
