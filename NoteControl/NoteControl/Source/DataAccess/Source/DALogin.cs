using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteControl.Source.DataAccess.Source
{
    public class DALogin : IDisposable
    {
        private readonly NoteControlContext _db = new NoteControlContext();
        private Usuario usuarioEncontrado;
        
        public Usuario getUser()
        {
           
            return this.usuarioEncontrado;
        }
        public bool userExist(string userName, string password) {
           var usuario = from user in _db.Usuarios
                           where (user.Nombre == userName
                           && user.Clave == password)
                           select user;
            usuarioEncontrado = usuario.First();
            return (usuario.Count() != 0) ? true : false;
        }

        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
