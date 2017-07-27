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
        public void crearUsuario(Usuario user,string perfil)
        {
            try
            {
                _da.crearUsuario(user,perfil);
                MessageBox.Show("Perfil Creado Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
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

        public void eliminarUser(string nombre)
        {
            try
            {
                _da.eliminarUsuario(nombre);
                MessageBox.Show("Usuario Eliminado Exitosamente");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void modificarUser(Usuario updatedUser, string nombre,string perfil)
        {
            try
            {
                _da.modificarUser(updatedUser, nombre, perfil);
                MessageBox.Show("Datos de "+nombre+" modificados exitosamente");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
