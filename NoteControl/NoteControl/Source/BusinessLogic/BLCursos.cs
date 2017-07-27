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
   public class BLCursos
    {
        DACursos _da = new DACursos();
        //metodo para agregar un curso
        public void crearCurso(Curso curso)
        {
            try
            {
                _da.crearCurso(curso);
                MessageBox.Show("Curso Creado Exitosamente!");
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //metodo para listar todos los cursos
        public List<Curso> listarCursos()
        {
            try
            {
                return _da.listarCursos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void modificarCurso(Curso curso, string textBoxCodeCurso)
        {
            try
            {
                _da.modificarCurso(curso, textBoxCodeCurso);
                MessageBox.Show("Curso "+textBoxCodeCurso+" modificado con exito");
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        public void eliminarCurso(string textBoxCodeCurso)
        {
            try
            {
                _da.eliminarCurso(textBoxCodeCurso);
                MessageBox.Show("Curso " + textBoxCodeCurso + "fue eliminado");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
