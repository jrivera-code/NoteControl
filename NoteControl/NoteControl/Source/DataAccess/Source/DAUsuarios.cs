using NoteControl.Source.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void eliminarUsuario(string nombre)
        {
            Usuario user = _db.Usuarios.Where(p => p.Nombre == nombre).First();
            _db.Usuarios.Remove(user);
            _db.SaveChanges();
        }

        public void modificarUser(Usuario updatedUser, string nombre,string perf)
        {
            MessageBox.Show(perf);
            var perfil = _db.Perfiles.FirstOrDefault(p => p.Nombre == perf);
            var usuario = _db.Usuarios.FirstOrDefault(a => a.Nombre == nombre);
           
            if (usuario != null)
            {
                updatedUser.Perfiles = perfil;
                _db.Usuarios.Remove(usuario);
                _db.Usuarios.Add(updatedUser);
            }
            else 
            {
                _db.Usuarios.Add(updatedUser);
            }
            _db.SaveChanges();
           
        }
    }
}
