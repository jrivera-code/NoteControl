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
   public class BLUsuarios
    {
        DAUsuarios _da = new DAUsuarios();
        //metodo para agregar un nuevo usuario
        public void CrearUsuario(Usuario user,string perfil)
        {
            try
            {
                _da.CrearUsuario(user,perfil);
                MessageBox.Show("Perfil Creado Exitosamente!");
            }
            catch
            {
                throw;
            }

        }
        //metodo para listar todos los usuarios
        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return _da.ListarUsuarios();
            }
            catch 
            {
                throw;
            }
        }

        public void EliminarUser(string nombre)
        {
            try
            {
                _da.EliminarUsuario(nombre);
                MessageBox.Show("Usuario Eliminado Exitosamente");
            }
            catch 
            {
                throw;
            }
        }

        public void ModificarUser(Usuario updatedUser, string nombre,string perfil)
        {
            try
            {
                _da.ModificarUser(updatedUser, nombre, perfil);
                MessageBox.Show("Datos de "+nombre+" modificados exitosamente");
            }
            catch 
            {
                throw;
            }
        }
    }
}
