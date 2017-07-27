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

        //metodo para agregar un nuevo usuario
        public void crearUsuario(Usuario user,string perfil)
        {
            user.Perfiles = _db.Perfiles.Where(p => p.Nombre == perfil).First();
            _db.Usuarios.Add(user);
            _db.SaveChanges();
        }
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
